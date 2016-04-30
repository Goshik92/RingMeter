/*
*
* Date: 2013
* Author: Goshik (goshik92@gmail.com)
*
*
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
*/

using System.Linq;
using OpenCvSharp;

namespace RingMeter
{
	/// <summary>
	/// Класс для калиброки камеры
	/// Для калиброки нужно установить изображение с помощью SetImage, а затем вызвать метод TryToCalibrate
	/// Затем можно преобразовывать координаты точек на изображении в координаты точек в реальном мире (см. класс CoordinatesTransformer)
	/// </summary>
	class CameraCalibrator
	{
		private IplImage grayChessBoard;
		private IplImage chessBoard;
		
		/// <summary>
		/// Ограничение числа итераций при уточнении координат углов шахматной доски
		/// </summary>
		public int MaxIterations = 100;

		/// <summary>
		/// Ограничение точности при уточнении координат углов шахматной доски
		/// </summary>
		public double Epsilon = 1.0e-6;

		/// <summary>
		/// Количество углов в столбце и в строке на изображении шахматного поля
		/// </summary>
		public CvSize CornersPattern = new CvSize(3, 3);

		/// <summary>
		/// Размер клетки шахматного поля в реальных единицах
		/// </summary>
		public float CellSize = 1.0f;

		/// <summary>
		/// Определеяет нужно-ли вычислять коэффициенты дисторсии при калибровке
		/// </summary>
		public bool UseUndistort = true;

		/// <summary>
		/// Откалиброванная зона
		/// </summary>
		public CvPoint[] CalibratedZone = new CvPoint[4];

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="imageSize">Размер изображения, которое будет применяться для калиброви</param>
		public CameraCalibrator(CvSize imageSize)
		{
			grayChessBoard = new IplImage(imageSize, BitDepth.U8, 1);
		}

		/// <summary>
		/// Устанавливает изображение, по которому будет проводится калиброка
		/// </summary>
		/// <param name="chessBoard">Изображение для калибровки</param>
		/// <returns></returns>
		public bool SetImage(IplImage chessBoard)
		{
			if (chessBoard.Size != grayChessBoard.Size) return false;
			this.chessBoard = chessBoard;
			return true;
		}

		/// <summary>
		/// Находит углы в изображении шахматной доски, установленном с помощью SetImage
		/// </summary>
		/// <param name="corners">Найденные углы</param>
		/// <returns>Показывает соответствуют-ли найленные углы шаблону CornersPattern</returns>
		public bool FindCorners(out CvPoint2D32f[] corners)
		{
			bool result;
			int numCorners;
			ChessboardFlag flags = ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage | ChessboardFlag.FilterQuads;
			CvTermCriteria criteria = new CvTermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, MaxIterations, Epsilon);

			// Находим углы
			result = chessBoard.FindChessboardCorners(CornersPattern, out corners, out numCorners, flags);

			// Уточнаем положение углов
			chessBoard.CvtColor(grayChessBoard, ColorConversion.RgbToGray);
			grayChessBoard.FindCornerSubPix(corners, corners.Length, new CvSize(11, 11), new CvSize(-1, -1), criteria);

			return result;
		}

		/// <summary>
		/// Находит углы в изображении шахматной доски, установленном с помощью SetImage и отмечает их на этом изображении
		/// </summary>
		/// <returns></returns>
		public bool FindCorners()
		{
			CvPoint2D32f[] corners;
			bool result = FindCorners(out corners);
			chessBoard.DrawChessboardCorners(CornersPattern, corners, result);
			return result;
		}

		/// <summary>
		/// Пытается произвести калибровку камеры
		/// </summary>
		/// <returns>Результат калибровки</returns>
		public bool TryToCalibrate(out CoordinatesTransformer transformer)
		{
			CvPoint2D32f[] imageCornersArray;
			transformer = new CoordinatesTransformer();

			// Пытаемся найти углы шахматной доски
			if (FindCorners(out imageCornersArray))
			{
				// Преобразуем массивы точек в матрицы
				CvMat imageCorners = new CvMat(imageCornersArray.Length, 1, MatrixType.F32C2, imageCornersArray);
				CvMat numCorners = new CvMat(1, 1, MatrixType.S32C1, new CvScalar(imageCornersArray.Length));

				// Определяем нужно-ли считать коэффициенты дисторсии
				CalibrationFlag flag = UseUndistort ? CalibrationFlag.RationalModel : CalibrationFlag.ZeroTangentDist | CalibrationFlag.FixK1 | CalibrationFlag.FixK2;

				// Производим калибровку
				Cv.CalibrateCamera2
				(
					generateCorners(),
					imageCorners,
					numCorners,
					chessBoard.Size,
					transformer.Intrinsic,
					transformer.Distortion,
					transformer.Rotation,
					transformer.Translation,
					flag
				);

				// Определяем прямоугольник в котором произведена калибровка
				CalibratedZone[0] = imageCornersArray[0];
				CalibratedZone[1] = imageCornersArray[CornersPattern.Width - 1];
				CalibratedZone[2] = imageCornersArray.Last();
				CalibratedZone[3] = imageCornersArray[CornersPattern.Width * (CornersPattern.Height - 1)];

				// Расчитываем матрицу перехода
				calculateTransformationMatrix(transformer);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Расчитывает матрицу перехода
		/// Взято здесь http://jepsonsblog.blogspot.ru/2012/11/rotation-in-3d-using-opencvs.html
		/// </summary>
		private void calculateTransformationMatrix(CoordinatesTransformer transformer)
		{ 
			// Матрица поворота 3x3
			CvMat R3x3 = new CvMat(3, 3, MatrixType.F64C1);
			Cv.Rodrigues2(transformer.Rotation, R3x3);

			// Произведение матрицы поворота и матрицы переноса
			CvMat RxT = new CvMat(4, 4, MatrixType.F64C1, new double[,]
			{
				{R3x3[0, 0], R3x3[0, 1], R3x3[0, 2], transformer.Translation[0, 0]},
				{R3x3[1, 0], R3x3[1, 1], R3x3[1, 2], transformer.Translation[0, 1]},
				{R3x3[2, 0], R3x3[2, 1], R3x3[2, 2], transformer.Translation[0, 2]},
				{0,          0,          0,          1                },
			});

			CvMat A1 = new CvMat(4, 3, MatrixType.F64C1, new double[,]
			{
				{1, 0, 0},
				{0, 1, 0},
				{0, 0, 0},
				{0, 0, 1}
			});
			
			CvMat A2 = new CvMat(3, 4, MatrixType.F64C1, new double[,]
			{
				{transformer.Intrinsic[0, 0], 0,                           transformer.Intrinsic[0, 2], 0},
				{0,                           transformer.Intrinsic[1, 1], transformer.Intrinsic[1, 2], 0},
				{0,                           0,                            1,                          0},
			});

			CvMat InvTransformationMatrix = (A2 * (RxT * A1));
			InvTransformationMatrix.Invert(transformer.TransformationMatrix);
		}

		/// <summary>
		/// Генератор координат углов шахматной доски с заданным размером
		/// </summary>
		/// <returns>Сгенерированные координаты углов</returns>
		private CvMat generateCorners()
		{
			int rowNum = CornersPattern.Height;
			int colNum = CornersPattern.Width;
			CvPoint3D32f[,] corners = new CvPoint3D32f[rowNum, colNum];

			for (int i = 0; i < rowNum; i++) for (int j = 0; j < colNum; j++)
			{
				corners[i, j] = new CvPoint3D32f(i * CellSize, j * CellSize, 0);
			}

			return new CvMat(rowNum * colNum, 3, MatrixType.F32C1, corners);
		}
	}
}
