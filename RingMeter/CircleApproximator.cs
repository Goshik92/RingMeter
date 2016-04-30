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

namespace RingMeter
{
	class CircleApproximator
	{
		/// <summary>
		/// Аппроксимирует набор точек окружностью
		/// http://forum.sources.ru/index.php?showtopic=354082&view=findpost&p=3107176
		/// </summary>
		/// <param name="points">Аппроксимируемые точки</param>
		/// <returns>Получившаяся окружность</returns>
		public static CvCircleSegment Approximate(CvPoint2D32f[] points)
		{
			CvCircleSegment result = new CvCircleSegment();
			CvMat y = new CvMat(points.Length, 1, MatrixType.F32C1);
			CvMat X = new CvMat(points.Length, 3, MatrixType.F32C1);
			CvMat b = new CvMat(3, 1, MatrixType.F32C1);

			for (int i = 0; i < points.Length; i++)
			{ 
				y[i, 0] = -1 * (points[i].X * points[i].X + points[i].Y * points[i].Y);
				X[i, 0] = points[i].X;
				X[i, 1] = points[i].Y;
				X[i, 2] = 1;
			}

			Cv.Solve(X, y, b, InvertMethod.Svd);

			result.Center.X = (float)(b[0, 0] / -2.0);
			result.Center.Y = (float)(b[1, 0] / -2.0);
			result.Radius = (float)Math.Sqrt(result.Center.X * result.Center.X + result.Center.Y * result.Center.Y - b[2, 0]);

			return result;
		}

		public static CvCircleSegment Approximate(CvPoint[] points)
		{
			CvPoint2D32f[] points2D32f = new CvPoint2D32f[points.Length];

			for (int i = 0; i < points.Length; i++)
			{
				points2D32f[i].X = (float)points[i].X;
				points2D32f[i].Y = (float)points[i].Y;
			}

			return Approximate(points2D32f);
		}
	}
}
