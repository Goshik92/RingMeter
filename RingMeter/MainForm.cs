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
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;

namespace RingMeter
{
	public partial class MainForm : Form
	{
		private string[] webCamsList;
		private MainFormStateObserver observer;
		private ImageProcessingRoutine routine;

		/// <summary>
		/// Доступные разрешения для камеры
		/// </summary>
		private CvSize[] webCamFrameSizes = new CvSize[]
		{
			new CvSize(160, 120),
			new CvSize(320, 240),
			new CvSize(640, 480)
		};

		public MainForm()
		{
			InitializeComponent();

			// Добавляем список камер в комбобокс
			webCamsList = WebCam.GetDevicesList();
			webCamChoiceComboBox.Items.AddRange(webCamsList);

			// Добавляем разрешения камеры в комбобокс
			foreach (CvSize size in webCamFrameSizes)
			{
				string s = size.Width.ToString() + " X " + size.Height.ToString();
				webCamFrameSizeComboBox.Items.Add(s);
			}

			// Наблюдаем за состоянием формы
			observer = new MainFormStateObserver();
			observer.ChangeStateEvent += onFormStateChange;
			observer.State = MainFormStateObserver.FormState.WebCamNotChosen;
		}

		/// <summary>
		/// Действие кнопки "Начать"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartCameraButton_Click(object sender, EventArgs e)
		{
			try
			{
				// Инициализируем обработчик изображения
				routine = new ImageProcessingRoutine
				(
					webCamChoiceComboBox.SelectedIndex,
					webCamFrameSizes[webCamFrameSizeComboBox.SelectedIndex]
				);

				routine.BeforeProcessingEvent += refrashForm;
				routine.GetImageEvent += onRefrashImage;
				routine.DrawCornersEvent += onRefrashImage;
				routine.FindContoursEvent += onRefrashImage;
				routine.CalibrateEvent += onCalibrate;
				routine.MeasureEvent += onMeasure;

				// Меняем состояние формы
				observer.State = MainFormStateObserver.FormState.WebCamChosen;
			}

			catch(Exception)
			{
				MessageBox.Show("Ошибка при выборе веб-камеры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Действие кнопки "Закончить"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StopCameraButton_Click(object sender, EventArgs e)
		{
			observer.State = MainFormStateObserver.FormState.WebCamNotChosen;
			routine.Stop();
		}

		/// <summary>
		/// Срабатывает при изменении состояния формы
		/// </summary>
		/// <param name="formState"></param>
		private bool onFormStateChange(MainFormStateObserver.FormState oldState, MainFormStateObserver.FormState newState)
		{
			if
			(
				oldState == MainFormStateObserver.FormState.WebCamNotChosen &&
				newState != MainFormStateObserver.FormState.WebCamChosen
			)
			{
				return false;
			}

			switch(newState)
			{
				// Выбор камеры
				case MainFormStateObserver.FormState.WebCamNotChosen:
				{
					((Control)measurementTabPage).Enabled = false;
					((Control)findContourTabPage).Enabled = false;
					((Control)calibrationTabPage).Enabled = false;
					webCamChoiceComboBox.Enabled = true;
					webCamFrameSizeComboBox.Enabled = true;
					StartCameraButton.Enabled = true;
					StopCameraButton.Enabled = false;
					break;
				}

				// Состояние возникшее после выбора камеры
				case MainFormStateObserver.FormState.WebCamChosen:
				{
					((Control)measurementTabPage).Enabled = true;
					((Control)findContourTabPage).Enabled = true;
					((Control)calibrationTabPage).Enabled = true;
					webCamChoiceComboBox.Enabled = false;
					webCamFrameSizeComboBox.Enabled = false;
					StartCameraButton.Enabled = false;
					StopCameraButton.Enabled = true;
					observer.State = MainFormStateObserver.FormState.Settings;
					routine.Run(ImageProcessingRoutine.RoutineAction.GetImage);
					break;
				}

				// Настройка камеры
				case MainFormStateObserver.FormState.Settings:
				{
					routine.Run(ImageProcessingRoutine.RoutineAction.GetImage);
					break;
				}

				// Процесс измерения
				case MainFormStateObserver.FormState.Measurement:
				{
					routine.Run(ImageProcessingRoutine.RoutineAction.Measure);
					break;
				}

				// Подбор фона
				case MainFormStateObserver.FormState.FindContour:
				{
					routine.Run(ImageProcessingRoutine.RoutineAction.FindContour);
					break;
				}

				// Калибровка
				case MainFormStateObserver.FormState.Calibration:
				{
					routine.Run(ImageProcessingRoutine.RoutineAction.DrawCorners);
					break;
				}
			}

			return true;
		}

		private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			TabPage page = mainTabControl.SelectedTab;

			// Открылась вкладка с настройками
			if (page == settingsTabPage)
			{
				observer.State = MainFormStateObserver.FormState.Settings;
			}

			// Открылась вкладка измерение
			else if (page == measurementTabPage)
			{
				observer.State = MainFormStateObserver.FormState.Measurement;
			}

			// Открылась вкладка выбора фона 
			else if (page == findContourTabPage)
			{
				observer.State = MainFormStateObserver.FormState.FindContour;
			}

			// Открылась вкладка калибровки
			else if (page == calibrationTabPage)
			{
				observer.State = MainFormStateObserver.FormState.Calibration;
			}
		}

		/// <summary>
		/// Действие кнопки "калибровать"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void calibrateButton_Click(object sender, EventArgs e)
		{
			routine.RunOnce(ImageProcessingRoutine.RoutineAction.Calibrate);
		}

		private void onRefrashImage(Bitmap image)
		{
			MethodInvoker mi = (MethodInvoker)delegate
			{
				videoPictureBox.Image = image;
			};

			if (InvokeRequired) Invoke(mi);
			else mi();
		}

		/// <summary>
		/// Действия формы при калибровке
		/// </summary>
		/// <param name="success"></param>
		private void onCalibrate(bool success)
		{
			if (success)
			{
				MessageBox.Show
				(
					"Калибровка прошла успешно",
					"Результат калибровки",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}

			else
			{
				MessageBox.Show
				(
					"Ошибка калибровки. Возможно количество найденных углов не соответствует указанному шаблону.",
					"Результат калибровки",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}

			routine.Run(ImageProcessingRoutine.RoutineAction.DrawCorners);
		}

		/// <summary>
		/// Загружает данные из формы в объект управляющий обработкой изображений
		/// </summary>
		private void refrashForm()
		{
			MethodInvoker mi = (MethodInvoker)delegate
			{
				routine.Camera.NumFrames = (int)NumFramesNumericUpDown.Value;

				float.TryParse(cellSizeTextBox.Text, out routine.Calibrator.CellSize);
				routine.Calibrator.CornersPattern.Width = (int)numCornersInColNumericUpDown.Value;
				routine.Calibrator.CornersPattern.Height = (int)numCornersInRowNumericUpDown.Value;
				routine.Calibrator.MaxIterations = (int)maxIterationNumericUpDown.Value;
				routine.Calibrator.UseUndistort = useUndistortCheckBox.Checked;

				routine.Finder.BackgroundRange.HMin = HueRangeTrackBar.MinValue;
				routine.Finder.BackgroundRange.HMax = HueRangeTrackBar.MaxValue;
				routine.Finder.BackgroundRange.SMin = SaturationRangeTrackBar.MinValue;
				routine.Finder.BackgroundRange.SMax = SaturationRangeTrackBar.MaxValue;
				routine.Finder.BackgroundRange.VMin = ValueRangeTrackBar.MinValue;
				routine.Finder.BackgroundRange.VMax = ValueRangeTrackBar.MaxValue;

				float.TryParse(correctionMultiplierTextBox.Text, out routine.CorrectionMultiplier);
				float.TryParse(correctionOffsetTextBox.Text, out routine.CorrectionOffset);
			};

			if (InvokeRequired) Invoke(mi);
			else mi();
		}


		/// <summary>
		/// Обновление состояния формы при измерении
		/// </summary>
		/// <param name="image"></param>
		/// <param name="radius"></param>
		private void onMeasure(Bitmap image, float radius)
		{
			MethodInvoker mi = (MethodInvoker)delegate
			{
				videoPictureBox.Image = image;
				if (float.IsNaN(radius)) radius = 0;
				ringDiameterLabel.Text = string.Format("{0:0.0000} мм", radius * 2);
			};

			if (InvokeRequired) Invoke(mi);
			else mi();
		}

		/// <summary>
		/// Действие при закрытии формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (routine != null) routine.Stop();
		}
	}
}
