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

using OpenCvSharp;

namespace RingMeter
{
	/// <summary>
	/// Класс для поиска контуров изображения на фоне хроматического цвета
	/// </summary>
	class ContoursFinder
	{
		private CvSize size;
		private IplImage hsvImg;
		private IplImage hImg;
		private IplImage sImg;
		private IplImage vImg;
		private IplImage tmpImg;

		/// <summary>
		/// Диапазон цвета фона в пространстве HSV
		/// </summary>
		public HsvRange BackgroundRange = new HsvRange();

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="size">Размер обрабатываемого изображения</param>
		public ContoursFinder(CvSize size)
		{
			this.size = size;
			hsvImg = new IplImage(size, BitDepth.U8, 3);
			hImg = new IplImage(size, BitDepth.U8, 1);
			sImg = new IplImage(size, BitDepth.U8, 1);
			vImg = new IplImage(size, BitDepth.U8, 1);
			tmpImg = new IplImage(size, BitDepth.U8, 1);
		}

		/// <summary>
		/// Отделяет изображение от фона
		/// </summary>
		/// <param name="source">Исходное изображение</param>
		/// <param name="destinatation">Результат разделения</param>
		private void separateBackground(IplImage source, IplImage destinatation)
		{
			// Преобразуем иходное изображение в HSV
			source.CvtColor(hsvImg, ColorConversion.RgbToHsv);
			
			// Разбиваем изображение на отельные каналы
			hsvImg.CvtPixToPlane(hImg, sImg, vImg, null);

			// Если диапазон Hue состоит из 2х частей
			if (BackgroundRange.HMin > BackgroundRange.HMax)
			{
				hImg.InRangeS(CvScalar.RealScalar(BackgroundRange.HMin), CvScalar.RealScalar(HsvRange.MAX_H), tmpImg);
				hImg.InRangeS(CvScalar.RealScalar(HsvRange.MIN_H), CvScalar.RealScalar(BackgroundRange.HMax), hImg);
				Cv.Or(tmpImg, hImg, hImg);
			}

			// Если диапазон Hue состоит из 1 части
			else hImg.InRangeS(CvScalar.RealScalar(BackgroundRange.HMin), CvScalar.RealScalar(BackgroundRange.HMax), hImg);

			// Ограничиваем значение остальных цветовых компонент
			sImg.InRangeS(CvScalar.RealScalar(BackgroundRange.SMin), CvScalar.RealScalar(BackgroundRange.SMax), sImg);
			vImg.InRangeS(CvScalar.RealScalar(BackgroundRange.VMin), CvScalar.RealScalar(BackgroundRange.VMax), vImg);

			// Формируем окончательный результат
			Cv.And(hImg, sImg, destinatation);
			Cv.And(destinatation, vImg, destinatation);
			Cv.Not(destinatation, destinatation);
		}


		/// <summary>
		/// Находит контуры на изображении и выбирает из них самый длинный контур являющийся границей дырки
		/// </summary>
		/// <param name="image">Изображение на котором будем искать контуры</param>
		/// <returns>Результат поиска</returns>
		public CvPoint[] FindMostLengthHole(IplImage image)
		{
			CvMemStorage contours = new CvMemStorage();
			CvSeq<CvPoint> firstContour, mostLengthContour = null;
			double maxContourLength = 0, perim = 0;
			
			// Отделяем изображение от фона
			separateBackground(image, tmpImg);

			// Находим все контуры на изображении
			Cv.FindContours(tmpImg, contours, out firstContour, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxNone);

			// Если не найдено ни одного контура
			if (firstContour == null) return new CvPoint[0];

			// Ищем самый длинный контур
			for (CvSeq<CvPoint> currentContour = firstContour; currentContour.HNext != null; currentContour = currentContour.HNext)
			{
				if (isHole(currentContour))
				{
					perim = Cv.ContourPerimeter(currentContour);
					
					if (perim >= maxContourLength)
					{
						maxContourLength = perim;
						mostLengthContour = currentContour;
					}
				}
			}

			// Если не найдено ни одной дырки
			if (mostLengthContour == null) return new CvPoint[0];

			return mostLengthContour.ToArray();
		}

		/// <summary>
		/// Определяет является-ли контур границей дырки
		/// </summary>
		/// <param name="contour"></param>
		/// <returns></returns>
		private static bool isHole(CvSeq<CvPoint> contour)
		{
			return (contour.Flags & (int)SeqType.FlagHole) != 0;
		}
	}
}
