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
using VideoInputSharp;

namespace RingMeter
{
	class WebCam
	{
		private int deviceId;
		private VideoInput vi;
		private IplImage sum;
		private IplImage tmp;
		private CvSize frameSize;

		/// <summary>
		/// Размер кадра выдаваемого камерой
		/// </summary>
		public CvSize FrameSize
		{
			get { return frameSize; }
		}

		/// <summary>
		/// Количество кадров, которое будет попиксельно усреднено при захвате для подавления помех
		/// </summary>
		public int NumFrames = 3;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="deviceId">ID камеры с которой будут захватываться кадры</param>
		/// <param name="frameSize">Желаемое разрешение кадров</param>
		public WebCam(int deviceId, CvSize frameSize)
		{
			this.deviceId = deviceId;
			vi = new VideoInput();
			vi.SetupDevice(deviceId, frameSize.Width, frameSize.Height);

			this.frameSize = new CvSize(vi.GetWidth(deviceId), vi.GetHeight(deviceId));
			sum = new IplImage(this.frameSize, BitDepth.F32, 3);
			tmp = new IplImage(this.frameSize, BitDepth.U8, 3);
		}

		/// <summary>
		/// Захватывает кадр с камеры
		/// </summary>
		/// <param name="result">Результат захвата и усреднения (3 канала U8)</param>
		public void GetIplImage(ref IplImage result)
		{
			sum.Set(new CvScalar(0, 0, 0));

			for (int i = 0; i < NumFrames; i++)
			{
				tmp.CopyPixelData(vi.GetPixels(deviceId, false, true));
				Cv.Acc(tmp, sum);
			}

			Cv.ConvertScale(sum, result, 1.0 / NumFrames, 0);
		}

		/// <summary>
		/// Открывает окно настройки камеры.
		/// По непонятным причинам окно подвешивается.
		/// </summary>
		public void OpenSettings()
		{
			vi.ShowSettingsWindow(deviceId);
		}

		/// <summary>
		/// Освобобождает камеру после использования
		/// </summary>
		public void Close()
		{
			vi.StopDevice(deviceId);
		}

		/// <summary>
		/// Выдает список доступных камер в виде массива строк, где индекс массва - ID камеры, а значение элемента - текстовое название камеры
		/// </summary>
		/// <returns>Список камер в виде массива строк</returns>
		public static string[] GetDevicesList()
		{
			int num = VideoInput.ListDevices();
			string[] res = new string[num];

			for (int i = 0; i < num; i++) res[i] = VideoInput.GetDeviceName(i);
			return res;
		}
	}
}
