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
using System.Threading;
using OpenCvSharp;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RingMeter
{
	/// <summary>
	/// Класс для получения изображения с камеры и его обработки
	/// Операции выполняются в отдельном потоке
	/// </summary>
	class ImageProcessingRoutine
	{
		/// <summary>
		/// Определяет режим работы обработчика изображения
		/// </summary>
		public enum RoutineAction
		{
 			/// <summary>
			/// Обработчик на паузе
 			/// </summary>
			Pause,

			/// <summary>
			/// Получение изображения с камеры
			/// </summary>
			GetImage,

			/// <summary>
			/// Поиск углов на шахматной доске и отметка их на изображении
			/// </summary>
			DrawCorners,

			/// <summary>
			/// Произвести калибровку
			/// </summary>
			Calibrate,

			/// <summary>
			/// Поиск контура кольца
			/// </summary>
			FindContour,

			/// <summary>
			/// Произвести измерение
			/// </summary>
			Measure
		}

		private Thread routineThread;
		private RoutineAction action;
		private bool isRunning = true;
		private bool isRunOnce = false;
		
		public delegate void GetImageDelegate(Bitmap image);
		public delegate void DrawCornersDelegate(Bitmap image);
		public delegate void CalibrateDelegate(bool success);
		public delegate void FindContoursDelegate(Bitmap image);
		public delegate void MeasureDelegate(Bitmap image, float radius);
		public delegate void BeforeProcessingDelegate();

		public event GetImageDelegate GetImageEvent;
		public event DrawCornersDelegate DrawCornersEvent;
		public event CalibrateDelegate CalibrateEvent;
		public event FindContoursDelegate FindContoursEvent;
		public event MeasureDelegate MeasureEvent;

		/// <summary>
		/// Событие возникающее перед выполнением обработки
		/// В его обработчике можно обновить настройки обработчика изображения
		/// </summary>
		public event BeforeProcessingDelegate BeforeProcessingEvent;

		public WebCam Camera;
		public CameraCalibrator Calibrator;
		public ContoursFinder Finder;
		public CoordinatesTransformer Transformer;
		public float CorrectionMultiplier = 1;
		public float CorrectionOffset = 0;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="deviceId">ID камеры которая будет использоваться для получения изображения</param>
		/// <param name="frameSize">Размер изображения которое будет обрабатываться</param>
		public ImageProcessingRoutine(int deviceId, CvSize frameSize)
		{
			Camera = new WebCam(deviceId, frameSize);
			Calibrator = new CameraCalibrator(Camera.FrameSize);
			Finder = new ContoursFinder(Camera.FrameSize);
			Transformer = new CoordinatesTransformer();

			routineThread = new Thread(routine);
			routineThread.IsBackground = true;
			routineThread.Start();
		}

		/// <summary>
		/// Создает объект, используя конфигурационный файл
		/// </summary>
		/// <param name="configFile">Файл с настройками</param>
		public static ImageProcessingRoutine CreateFromConfigFile(int deviceId, CvSize frameSize, string configFile)
		{
			ImageProcessingRoutine ipr = new ImageProcessingRoutine(deviceId, frameSize);

			// Десериализуем объект с настройками
			Stream configFileStream = File.OpenRead(configFile);
			BinaryFormatter deserializer = new BinaryFormatter();
			ImageProcessingConfig ipc = (ImageProcessingConfig)deserializer.Deserialize(configFileStream);
			configFileStream.Close();

			// Настраиваем обработчик изображений
			ipr.Transformer = ipc.Transformer;
			ipr.Finder.BackgroundRange = ipc.BackgroundRange;
			ipr.CorrectionOffset = ipc.CorrectionOffset;
			ipr.CorrectionMultiplier = ipc.CorrectionMultiplier;

			return ipr;
		}

		/// <summary>
		/// Запускает указанную операцию один раз
		/// </summary>
		/// <param name="action">Запускаемая операция</param>
		public void RunOnce(RoutineAction action)
		{
			isRunOnce = true;
			this.action = action;
		}

		/// <summary>
		/// Заставляет указанную операцию выполнятся циклически
		/// </summary>
		/// <param name="action">Запускаемая операция</param>
		public void Run(RoutineAction action)
		{
			isRunOnce = false;
			this.action = action;
		}

		/// <summary>
		/// Останавливает поток
		/// </summary>
		public void Stop()
		{
			isRunning = false;
			routineThread.Join();
		}

		/// <summary>
		/// Обработка изображения выполняющаяся в отдельном потоке
		/// </summary>
		private void routine()
		{
			IplImage cam = new IplImage(Camera.FrameSize, BitDepth.U8, 3);
			CvPoint[] mostLengthHole = new CvPoint[0];
			RoutineAction innerAction;
			bool innerIsRunOnce;

			while(isRunning)
			{
				// Копируем новое значение состояния
				innerAction = action;
				innerIsRunOnce = isRunOnce;

				// Определяем что будем делать в следующем цикле
				if (innerIsRunOnce) action = RoutineAction.Pause; 

				// Если поток на паузе, то ничего не делаем
				if (innerAction == RoutineAction.Pause) continue;

				if (isRunning && BeforeProcessingEvent != null) BeforeProcessingEvent();
				
				// Захватываем изображение с камеры
				Camera.GetIplImage(ref cam);

				if (innerAction == RoutineAction.FindContour || innerAction == RoutineAction.Measure)
				{
					mostLengthHole = Finder.FindMostLengthHole(cam);
				}

				if (innerAction == RoutineAction.DrawCorners || innerAction == RoutineAction.Calibrate)
				{
					Calibrator.SetImage(cam);
				}

				switch (innerAction)
				{
					case RoutineAction.GetImage:
					{
						if (isRunning && GetImageEvent != null) GetImageEvent(cam.ToBitmap());
						break;
					}

					case RoutineAction.DrawCorners:
					{
						Calibrator.FindCorners();
						if (isRunning && DrawCornersEvent != null) DrawCornersEvent(cam.ToBitmap());
						break;
					}

					case RoutineAction.Calibrate:
					{
						bool result = Calibrator.TryToCalibrate(out Transformer);
						if (isRunning && CalibrateEvent != null) CalibrateEvent(result);
						break;
					}

					case RoutineAction.FindContour:
					{
						if (mostLengthHole.Length > 0) cam.DrawPolyLine(new CvPoint[][] { mostLengthHole }, true, Cv.RGB(0, 255, 0), 2);
						if (isRunning && FindContoursEvent != null) FindContoursEvent(cam.ToBitmap());
						break;
					}

					case RoutineAction.Measure:
					{
						if (mostLengthHole.Length > 0)
						{
							CvPoint2D32f[] realPoints = Transformer.GetRealPoints(mostLengthHole);
							CvCircleSegment realCircle = CircleApproximator.Approximate(realPoints);
							CvCircleSegment imageCircle = CircleApproximator.Approximate(mostLengthHole);

							// Вносим поправки
							float ratio = imageCircle.Radius / realCircle.Radius;
							realCircle.Radius = realCircle.Radius * CorrectionMultiplier + CorrectionOffset;
							imageCircle.Radius = imageCircle.Radius * CorrectionMultiplier + CorrectionOffset * ratio;

							int circleRadius = (int)Math.Round(imageCircle.Radius);
							CvPoint circleCenter = new CvPoint
							(
								(int)Math.Round(imageCircle.Center.X),
								(int)Math.Round(imageCircle.Center.Y)
							);

							// Обводим внутреннюю границу кольца
							if (circleRadius > 0) cam.DrawCircle(circleCenter, circleRadius, Cv.RGB(0, 0, 255), 2);
							
							// Отмечаем откалиброванную зону
							cam.DrawPolyLine(new CvPoint[][] { Calibrator.CalibratedZone }, true, Cv.RGB(255, 255, 0), 2);

							if (isRunning && MeasureEvent != null) MeasureEvent(cam.ToBitmap(), realCircle.Radius);
						}

						break;
					}
				}
			}

			Camera.Close();
		}
	}
}
