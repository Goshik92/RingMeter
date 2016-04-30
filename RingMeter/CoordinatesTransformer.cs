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

using System;
using OpenCvSharp;
using System.Runtime.Serialization;

namespace RingMeter
{
	/// <summary>
	/// Класс для преобразования координат точек на изображении в координаты точек в реальном мире
	/// </summary>
	[Serializable()]
	class CoordinatesTransformer : ISerializable
	{
		/// <summary>
		/// Матрица внутренней калибровки
		/// </summary>
		[NonSerialized()]
		public readonly CvMat Intrinsic = new CvMat(3, 3, MatrixType.F32C1);

		/// <summary>
		/// Коэффициенты дисторсии
		/// </summary>
		[NonSerialized()]
		public readonly CvMat Distortion = new CvMat(1, 8, MatrixType.F32C1);

		/// <summary>
		/// Матрица поворота
		/// </summary>
		[NonSerialized()]
		public readonly CvMat Rotation = new CvMat(1, 3, MatrixType.F64C1);

		/// <summary>
		/// Вектор переноса
		/// </summary>
		[NonSerialized()]
		public readonly CvMat Translation = new CvMat(1, 3, MatrixType.F64C1);

		/// <summary>
		/// Матрица перехода к координатам реального мира
		/// </summary>
		[NonSerialized()]
		public CvMat TransformationMatrix = new CvMat(3, 3, MatrixType.F64C1);

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public CoordinatesTransformer()
		{ 
		}

		/// <summary>
		/// Конструктор вызываемый при десериализации
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CoordinatesTransformer(SerializationInfo info, StreamingContext context)
		{
			Type t = typeof(CvMatSerializator);
			Intrinsic = ((CvMatSerializator)info.GetValue("Intrinsic", t)).BuildMatrix();
			Distortion = ((CvMatSerializator)info.GetValue("Distortion", t)).BuildMatrix();
			Rotation = ((CvMatSerializator)info.GetValue("Rotation", t)).BuildMatrix();
			Translation = ((CvMatSerializator)info.GetValue("Translation", t)).BuildMatrix();
			TransformationMatrix = ((CvMatSerializator)info.GetValue("TransformationMatrix", t)).BuildMatrix();
		}

		/// <summary>
		/// Преобразует координаты точек на изображении в условные координа точек в реальном мире
		/// </summary>
		/// <param name="imagePoints">Точки изображения</param>
		/// <returns>Точки в реальном мире</returns>
		public CvPoint2D32f[] GetRealPoints(CvPoint2D32f[] imagePoints)
		{
			// Определяем массивы и матрицы
			CvMat imagePointsMat = new CvMat(imagePoints.Length, 1, MatrixType.F32C2, imagePoints);
			CvMat undistortedPointsMat = new CvMat(imagePoints.Length, 1, MatrixType.F32C2);
			CvMat realPointsMat = new CvMat(imagePoints.Length, 1, MatrixType.F32C2);
			CvPoint2D32f[] realPoints = new CvPoint2D32f[imagePoints.Length];

			// Боремся с дисторсией
			Cv.Undistort2(imagePointsMat, undistortedPointsMat, Intrinsic, Distortion);

			// Применяем матрицу перехода
			Cv.PerspectiveTransform(imagePointsMat, realPointsMat, TransformationMatrix);

			// Преобразуем координаты на изображении в реальные
			for (int i = 0; i < imagePoints.Length; i++)
			{
				realPoints[i].X = (float)(realPointsMat[i].Val0);
				realPoints[i].Y = (float)(realPointsMat[i].Val1);
			}

			return realPoints;
		}

		/// <summary>
		/// Преобразует координаты точек на изображении в условные координа точек в реальном мире
		/// </summary>
		/// <param name="imagePoints">Точки изображения</param>
		/// <returns>Точки в реальном мире</returns>
		public CvPoint2D32f[] GetRealPoints(CvSeq<CvPoint> imagePoints)
		{
			CvPoint2D32f[] imagePoints2D32f = new CvPoint2D32f[imagePoints.Total];
			for (int i = 0; i < imagePoints.Total; i++)
			{
				imagePoints2D32f[i].X = (float)imagePoints[i].Value.X;
				imagePoints2D32f[i].Y = (float)imagePoints[i].Value.Y;
			}

			return GetRealPoints(imagePoints2D32f);
		}

		/// <summary>
		/// Преобразует координаты точек на изображении в условные координа точек в реальном мире
		/// </summary>
		/// <param name="imagePoints">Точки изображения</param>
		/// <returns>Точки в реальном мире</returns>
		public CvPoint2D32f[] GetRealPoints(CvPoint[] imagePoints)
		{
			CvPoint2D32f[] imagePoints2D32f = new CvPoint2D32f[imagePoints.Length];
			for (int i = 0; i < imagePoints.Length; i++)
			{
				imagePoints2D32f[i].X = (float)imagePoints[i].X;
				imagePoints2D32f[i].Y = (float)imagePoints[i].Y;
			}

			return GetRealPoints(imagePoints2D32f);
		}

		/// <summary>
		/// Восстанавливает матрицы при сериализации
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Intrinsic", new CvMatSerializator(Intrinsic));
			info.AddValue("Distortion", new CvMatSerializator(Distortion));
			info.AddValue("Rotation", new CvMatSerializator(Rotation));
			info.AddValue("Translation", new CvMatSerializator(Translation));
			info.AddValue("TransformationMatrix", new CvMatSerializator(TransformationMatrix));
		}
	}
}
