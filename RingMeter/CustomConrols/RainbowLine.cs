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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RingMeter.CustomConrols
{
	public partial class RainbowLine : PictureBox
	{
		public RainbowLine()
		{
			InitializeComponent();

			// Если мы не в режиме конструктора
			if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
			{
				this.SizeChanged += new System.EventHandler(this.RainbowLine_SizeChanged);
			}
		}

		/// <summary>
		/// Генерирует радужную линейку заданных размеров
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		private static IplImage GenerateRainbowLine(int width, int height)
		{
			IplImage result = new IplImage(new CvSize(width, height), BitDepth.U8, 3);
			IntPtr ptr = result.ImageData;

			for (int x = 0; x < result.Width; x++)
			{
				for (int y = 0; y < result.Height; y++)
				{
					int offset = (result.WidthStep * y) + (x * 3);
					byte val = (byte)Math.Round(180.0 * (x + 1) / result.Width);
					Marshal.WriteByte(ptr, offset + 0, val);
					Marshal.WriteByte(ptr, offset + 1, 255);
					Marshal.WriteByte(ptr, offset + 2, 255);
				}
			}

			result.CvtColor(result, ColorConversion.HsvToRgb);

			return result;
		}

		private void RainbowLine_SizeChanged(object sender, EventArgs e)
		{
			Image = GenerateRainbowLine(Width, Height).ToBitmap();
		}
	}
}
