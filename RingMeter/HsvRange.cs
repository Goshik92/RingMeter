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

namespace RingMeter
{
	/// <summary>
	/// Структура, которая хранит диапазон цвета в пространсте HSV
	/// </summary>
	[Serializable()]
	struct HsvRange
	{
		public const int MIN_H = 0;
		public const int MAX_H = 180;

		public const int MIN_S = 0;
		public const int MAX_S = 256;

		public const int MIN_V = 0;
		public const int MAX_V = 256;

		private int hMin;
		private int hMax;

		private int sMin;
		private int sMax;

		private int vMin;
		private int vMax;

		/// <summary>
		/// Нижнее значение компоненты hue
		/// </summary>
		public int HMin
		{
			get { return hMin; }
			set { hMin = range(value, MIN_H, MAX_H); }
		}

		/// <summary>
		/// Верхнее значение компоненты hue
		/// </summary>
		public int HMax
		{
			get { return hMax; }
			set { hMax = range(value, MIN_H, MAX_H); }
		}

		/// <summary>
		/// Нижнее значение компоненты saturation
		/// </summary>
		public int SMin
		{
			get { return sMin; }
			set { sMin = range(value, MIN_S, MAX_S); }
		}

		/// <summary>
		/// Верхнее значение компоненты saturation
		/// </summary>
		public int SMax
		{
			get { return sMax; }
			set { sMax = range(value, MIN_S, MAX_S); }
		}

		/// <summary>
		/// Нижнее значение компоненты value
		/// </summary>
		public int VMin
		{
			get { return vMin; }
			set { vMin = range(value, MIN_V, MAX_V); }
		}

		/// <summary>
		/// Верхнее значение компоненты value
		/// </summary>
		public int VMax
		{
			get { return vMax; }
			set { vMax = range(value, MIN_V, MAX_V); }
		}

		private static int range(int v, int min, int max)
		{
			return v < min ? min : (v > max ? max : v);
		}
	}
}
