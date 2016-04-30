namespace RingMeter
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.videoPictureBox = new System.Windows.Forms.PictureBox();
			this.calibrationTabPage = new System.Windows.Forms.TabPage();
			this.helpLink2 = new RingMeter.CustomConrols.HelpLink();
			this.useUndistortCheckBox = new System.Windows.Forms.CheckBox();
			this.maxIterationNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cellSizeTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.calibrateButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numCornersInColNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.numCornersInRowNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.helpLink1 = new RingMeter.CustomConrols.HelpLink();
			this.findContourTabPage = new System.Windows.Forms.TabPage();
			this.rainbowLine1 = new RingMeter.CustomConrols.RainbowLine();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.ValueRangeTrackBar = new RingMeter.CustomConrols.RangeTrackBar();
			this.SaturationRangeTrackBar = new RingMeter.CustomConrols.RangeTrackBar();
			this.HueRangeTrackBar = new RingMeter.CustomConrols.RangeTrackBar();
			this.settingsTabPage = new System.Windows.Forms.TabPage();
			this.webCamFrameSizeComboBox = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.StopCameraButton = new System.Windows.Forms.Button();
			this.StartCameraButton = new System.Windows.Forms.Button();
			this.webCamChoiceComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.WebCameraSettingsButton = new System.Windows.Forms.Button();
			this.FramesNumberLabel = new System.Windows.Forms.Label();
			this.NumFramesNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.NumFramesHelpLink = new RingMeter.CustomConrols.HelpLink();
			this.measurementTabPage = new System.Windows.Forms.TabPage();
			this.ringDiameterLabel = new System.Windows.Forms.Label();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.correctionMultiplierTextBox = new System.Windows.Forms.TextBox();
			this.correctionOffsetTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).BeginInit();
			this.calibrationTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxIterationNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCornersInColNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCornersInRowNumericUpDown)).BeginInit();
			this.findContourTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rainbowLine1)).BeginInit();
			this.settingsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumFramesNumericUpDown)).BeginInit();
			this.measurementTabPage.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// videoPictureBox
			// 
			this.videoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.videoPictureBox.Location = new System.Drawing.Point(12, 12);
			this.videoPictureBox.Name = "videoPictureBox";
			this.videoPictureBox.Size = new System.Drawing.Size(480, 360);
			this.videoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.videoPictureBox.TabIndex = 0;
			this.videoPictureBox.TabStop = false;
			// 
			// calibrationTabPage
			// 
			this.calibrationTabPage.Controls.Add(this.helpLink2);
			this.calibrationTabPage.Controls.Add(this.useUndistortCheckBox);
			this.calibrationTabPage.Controls.Add(this.maxIterationNumericUpDown);
			this.calibrationTabPage.Controls.Add(this.label7);
			this.calibrationTabPage.Controls.Add(this.label6);
			this.calibrationTabPage.Controls.Add(this.cellSizeTextBox);
			this.calibrationTabPage.Controls.Add(this.label5);
			this.calibrationTabPage.Controls.Add(this.calibrateButton);
			this.calibrationTabPage.Controls.Add(this.label4);
			this.calibrationTabPage.Controls.Add(this.label3);
			this.calibrationTabPage.Controls.Add(this.numCornersInColNumericUpDown);
			this.calibrationTabPage.Controls.Add(this.numCornersInRowNumericUpDown);
			this.calibrationTabPage.Controls.Add(this.helpLink1);
			this.calibrationTabPage.Location = new System.Drawing.Point(4, 22);
			this.calibrationTabPage.Name = "calibrationTabPage";
			this.calibrationTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.calibrationTabPage.Size = new System.Drawing.Size(324, 334);
			this.calibrationTabPage.TabIndex = 3;
			this.calibrationTabPage.Text = "Калибровка";
			this.calibrationTabPage.UseVisualStyleBackColor = true;
			// 
			// helpLink2
			// 
			this.helpLink2.AutoSize = true;
			this.helpLink2.HelpText = "Дисторсия - искажение вносимое линзами объектива";
			this.helpLink2.Location = new System.Drawing.Point(258, 157);
			this.helpLink2.Name = "helpLink2";
			this.helpLink2.Size = new System.Drawing.Size(13, 13);
			this.helpLink2.TabIndex = 12;
			this.helpLink2.TabStop = true;
			this.helpLink2.Text = "?";
			// 
			// useUndistortCheckBox
			// 
			this.useUndistortCheckBox.AutoSize = true;
			this.useUndistortCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.useUndistortCheckBox.Checked = true;
			this.useUndistortCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useUndistortCheckBox.Location = new System.Drawing.Point(25, 157);
			this.useUndistortCheckBox.Name = "useUndistortCheckBox";
			this.useUndistortCheckBox.Size = new System.Drawing.Size(227, 17);
			this.useUndistortCheckBox.TabIndex = 11;
			this.useUndistortCheckBox.Text = "Компенсировать дисторсию объектива";
			this.useUndistortCheckBox.UseVisualStyleBackColor = true;
			// 
			// maxIterationNumericUpDown
			// 
			this.maxIterationNumericUpDown.Location = new System.Drawing.Point(248, 98);
			this.maxIterationNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.maxIterationNumericUpDown.Name = "maxIterationNumericUpDown";
			this.maxIterationNumericUpDown.ReadOnly = true;
			this.maxIterationNumericUpDown.Size = new System.Drawing.Size(36, 20);
			this.maxIterationNumericUpDown.TabIndex = 9;
			this.maxIterationNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(25, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(207, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Макс. итераций в алгоритме уточнения";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(161, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "мм";
			// 
			// cellSizeTextBox
			// 
			this.cellSizeTextBox.Location = new System.Drawing.Point(115, 126);
			this.cellSizeTextBox.Name = "cellSizeTextBox";
			this.cellSizeTextBox.Size = new System.Drawing.Size(40, 20);
			this.cellSizeTextBox.TabIndex = 6;
			this.cellSizeTextBox.Text = "5";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 129);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Размер клетки";
			// 
			// calibrateButton
			// 
			this.calibrateButton.Location = new System.Drawing.Point(115, 206);
			this.calibrateButton.Name = "calibrateButton";
			this.calibrateButton.Size = new System.Drawing.Size(104, 33);
			this.calibrateButton.TabIndex = 4;
			this.calibrateButton.Text = "Калибровать";
			this.calibrateButton.UseVisualStyleBackColor = true;
			this.calibrateButton.Click += new System.EventHandler(this.calibrateButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Количество углов в столбце";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Количество углов в строке";
			// 
			// numCornersInColNumericUpDown
			// 
			this.numCornersInColNumericUpDown.Location = new System.Drawing.Point(248, 69);
			this.numCornersInColNumericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numCornersInColNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numCornersInColNumericUpDown.Name = "numCornersInColNumericUpDown";
			this.numCornersInColNumericUpDown.ReadOnly = true;
			this.numCornersInColNumericUpDown.Size = new System.Drawing.Size(36, 20);
			this.numCornersInColNumericUpDown.TabIndex = 1;
			this.numCornersInColNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// numCornersInRowNumericUpDown
			// 
			this.numCornersInRowNumericUpDown.Location = new System.Drawing.Point(248, 40);
			this.numCornersInRowNumericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numCornersInRowNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numCornersInRowNumericUpDown.Name = "numCornersInRowNumericUpDown";
			this.numCornersInRowNumericUpDown.ReadOnly = true;
			this.numCornersInRowNumericUpDown.Size = new System.Drawing.Size(36, 20);
			this.numCornersInRowNumericUpDown.TabIndex = 0;
			this.numCornersInRowNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// helpLink1
			// 
			this.helpLink1.AutoSize = true;
			this.helpLink1.HelpText = "Углом является точка касания двух черных квадратов на шахматной доске";
			this.helpLink1.Location = new System.Drawing.Point(290, 42);
			this.helpLink1.Name = "helpLink1";
			this.helpLink1.Size = new System.Drawing.Size(13, 13);
			this.helpLink1.TabIndex = 10;
			this.helpLink1.TabStop = true;
			this.helpLink1.Text = "?";
			// 
			// findContourTabPage
			// 
			this.findContourTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.findContourTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.findContourTabPage.Controls.Add(this.rainbowLine1);
			this.findContourTabPage.Controls.Add(this.label1);
			this.findContourTabPage.Controls.Add(this.button2);
			this.findContourTabPage.Controls.Add(this.button1);
			this.findContourTabPage.Controls.Add(this.ValueRangeTrackBar);
			this.findContourTabPage.Controls.Add(this.SaturationRangeTrackBar);
			this.findContourTabPage.Controls.Add(this.HueRangeTrackBar);
			this.findContourTabPage.Location = new System.Drawing.Point(4, 22);
			this.findContourTabPage.Name = "findContourTabPage";
			this.findContourTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.findContourTabPage.Size = new System.Drawing.Size(324, 334);
			this.findContourTabPage.TabIndex = 2;
			this.findContourTabPage.Text = "Подбор фона";
			// 
			// rainbowLine1
			// 
			this.rainbowLine1.Location = new System.Drawing.Point(50, 95);
			this.rainbowLine1.Name = "rainbowLine1";
			this.rainbowLine1.Size = new System.Drawing.Size(222, 10);
			this.rainbowLine1.TabIndex = 8;
			this.rainbowLine1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(313, 52);
			this.label1.TabIndex = 6;
			this.label1.Text = "Подберите диапазон цветового значения фона в пространстве HSV. Необходимо добится" +
    ", чтобы появившийся зеленый контур как можно точнее соответствовал отверстию в к" +
    "ольце.";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(179, 304);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(101, 24);
			this.button2.TabIndex = 5;
			this.button2.Text = "Сброс";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(38, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Сохранить";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// ValueRangeTrackBar
			// 
			this.ValueRangeTrackBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ValueRangeTrackBar.BottomValue = 0;
			this.ValueRangeTrackBar.Location = new System.Drawing.Point(6, 225);
			this.ValueRangeTrackBar.MaxText = "Vmax";
			this.ValueRangeTrackBar.MaxValue = 256;
			this.ValueRangeTrackBar.MinText = "Vmin";
			this.ValueRangeTrackBar.MinValue = 0;
			this.ValueRangeTrackBar.Name = "ValueRangeTrackBar";
			this.ValueRangeTrackBar.Size = new System.Drawing.Size(308, 70);
			this.ValueRangeTrackBar.TabIndex = 2;
			this.ValueRangeTrackBar.TopValue = 256;
			// 
			// SaturationRangeTrackBar
			// 
			this.SaturationRangeTrackBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SaturationRangeTrackBar.BottomValue = 0;
			this.SaturationRangeTrackBar.Location = new System.Drawing.Point(6, 145);
			this.SaturationRangeTrackBar.MaxText = "Smax";
			this.SaturationRangeTrackBar.MaxValue = 256;
			this.SaturationRangeTrackBar.MinText = "Smin";
			this.SaturationRangeTrackBar.MinValue = 0;
			this.SaturationRangeTrackBar.Name = "SaturationRangeTrackBar";
			this.SaturationRangeTrackBar.Size = new System.Drawing.Size(308, 70);
			this.SaturationRangeTrackBar.TabIndex = 1;
			this.SaturationRangeTrackBar.TopValue = 256;
			// 
			// HueRangeTrackBar
			// 
			this.HueRangeTrackBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HueRangeTrackBar.BottomValue = 0;
			this.HueRangeTrackBar.Location = new System.Drawing.Point(6, 65);
			this.HueRangeTrackBar.MaxText = "Hmax";
			this.HueRangeTrackBar.MaxValue = 150;
			this.HueRangeTrackBar.MinText = "Hmin";
			this.HueRangeTrackBar.MinValue = 30;
			this.HueRangeTrackBar.Name = "HueRangeTrackBar";
			this.HueRangeTrackBar.Size = new System.Drawing.Size(308, 70);
			this.HueRangeTrackBar.TabIndex = 0;
			this.HueRangeTrackBar.TopValue = 180;
			// 
			// settingsTabPage
			// 
			this.settingsTabPage.Controls.Add(this.webCamFrameSizeComboBox);
			this.settingsTabPage.Controls.Add(this.label8);
			this.settingsTabPage.Controls.Add(this.StopCameraButton);
			this.settingsTabPage.Controls.Add(this.StartCameraButton);
			this.settingsTabPage.Controls.Add(this.webCamChoiceComboBox);
			this.settingsTabPage.Controls.Add(this.label2);
			this.settingsTabPage.Controls.Add(this.WebCameraSettingsButton);
			this.settingsTabPage.Controls.Add(this.FramesNumberLabel);
			this.settingsTabPage.Controls.Add(this.NumFramesNumericUpDown);
			this.settingsTabPage.Controls.Add(this.NumFramesHelpLink);
			this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
			this.settingsTabPage.Name = "settingsTabPage";
			this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.settingsTabPage.Size = new System.Drawing.Size(324, 334);
			this.settingsTabPage.TabIndex = 1;
			this.settingsTabPage.Text = "Настройки";
			this.settingsTabPage.UseVisualStyleBackColor = true;
			// 
			// webCamFrameSizeComboBox
			// 
			this.webCamFrameSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.webCamFrameSizeComboBox.FormattingEnabled = true;
			this.webCamFrameSizeComboBox.Location = new System.Drawing.Point(136, 49);
			this.webCamFrameSizeComboBox.Name = "webCamFrameSizeComboBox";
			this.webCamFrameSizeComboBox.Size = new System.Drawing.Size(169, 21);
			this.webCamFrameSizeComboBox.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(26, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Выбор разрешения";
			// 
			// StopCameraButton
			// 
			this.StopCameraButton.Location = new System.Drawing.Point(117, 81);
			this.StopCameraButton.Name = "StopCameraButton";
			this.StopCameraButton.Size = new System.Drawing.Size(72, 41);
			this.StopCameraButton.TabIndex = 12;
			this.StopCameraButton.Text = "Закончить";
			this.StopCameraButton.UseVisualStyleBackColor = true;
			this.StopCameraButton.Click += new System.EventHandler(this.StopCameraButton_Click);
			// 
			// StartCameraButton
			// 
			this.StartCameraButton.Location = new System.Drawing.Point(29, 81);
			this.StartCameraButton.Name = "StartCameraButton";
			this.StartCameraButton.Size = new System.Drawing.Size(82, 41);
			this.StartCameraButton.TabIndex = 11;
			this.StartCameraButton.Text = "Начать";
			this.StartCameraButton.UseVisualStyleBackColor = true;
			this.StartCameraButton.Click += new System.EventHandler(this.StartCameraButton_Click);
			// 
			// webCamChoiceComboBox
			// 
			this.webCamChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.webCamChoiceComboBox.FormattingEnabled = true;
			this.webCamChoiceComboBox.Location = new System.Drawing.Point(136, 22);
			this.webCamChoiceComboBox.Name = "webCamChoiceComboBox";
			this.webCamChoiceComboBox.Size = new System.Drawing.Size(169, 21);
			this.webCamChoiceComboBox.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Выбор веб-камеры";
			// 
			// WebCameraSettingsButton
			// 
			this.WebCameraSettingsButton.Enabled = false;
			this.WebCameraSettingsButton.Location = new System.Drawing.Point(195, 81);
			this.WebCameraSettingsButton.Name = "WebCameraSettingsButton";
			this.WebCameraSettingsButton.Size = new System.Drawing.Size(110, 41);
			this.WebCameraSettingsButton.TabIndex = 5;
			this.WebCameraSettingsButton.Text = "Настройки веб-камеры";
			this.WebCameraSettingsButton.UseVisualStyleBackColor = true;
			// 
			// FramesNumberLabel
			// 
			this.FramesNumberLabel.AutoSize = true;
			this.FramesNumberLabel.Location = new System.Drawing.Point(26, 142);
			this.FramesNumberLabel.Name = "FramesNumberLabel";
			this.FramesNumberLabel.Size = new System.Drawing.Size(105, 13);
			this.FramesNumberLabel.TabIndex = 1;
			this.FramesNumberLabel.Text = "Количество кадров";
			// 
			// NumFramesNumericUpDown
			// 
			this.NumFramesNumericUpDown.Location = new System.Drawing.Point(137, 140);
			this.NumFramesNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.NumFramesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumFramesNumericUpDown.Name = "NumFramesNumericUpDown";
			this.NumFramesNumericUpDown.ReadOnly = true;
			this.NumFramesNumericUpDown.Size = new System.Drawing.Size(33, 20);
			this.NumFramesNumericUpDown.TabIndex = 0;
			this.NumFramesNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// NumFramesHelpLink
			// 
			this.NumFramesHelpLink.AutoSize = true;
			this.NumFramesHelpLink.HelpText = "Количество снимков для попиксельного усреднения. Позволяет избавиться от шума, но" +
    " замедляет процесс измерения.";
			this.NumFramesHelpLink.Location = new System.Drawing.Point(176, 142);
			this.NumFramesHelpLink.Name = "NumFramesHelpLink";
			this.NumFramesHelpLink.Size = new System.Drawing.Size(13, 13);
			this.NumFramesHelpLink.TabIndex = 2;
			this.NumFramesHelpLink.TabStop = true;
			this.NumFramesHelpLink.Text = "?";
			// 
			// measurementTabPage
			// 
			this.measurementTabPage.Controls.Add(this.label12);
			this.measurementTabPage.Controls.Add(this.correctionOffsetTextBox);
			this.measurementTabPage.Controls.Add(this.correctionMultiplierTextBox);
			this.measurementTabPage.Controls.Add(this.label10);
			this.measurementTabPage.Controls.Add(this.label9);
			this.measurementTabPage.Controls.Add(this.ringDiameterLabel);
			this.measurementTabPage.Location = new System.Drawing.Point(4, 22);
			this.measurementTabPage.Name = "measurementTabPage";
			this.measurementTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.measurementTabPage.Size = new System.Drawing.Size(324, 334);
			this.measurementTabPage.TabIndex = 0;
			this.measurementTabPage.Text = "Измерение";
			this.measurementTabPage.UseVisualStyleBackColor = true;
			// 
			// ringDiameterLabel
			// 
			this.ringDiameterLabel.AutoSize = true;
			this.ringDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ringDiameterLabel.Location = new System.Drawing.Point(81, 137);
			this.ringDiameterLabel.Name = "ringDiameterLabel";
			this.ringDiameterLabel.Size = new System.Drawing.Size(169, 37);
			this.ringDiameterLabel.TabIndex = 2;
			this.ringDiameterLabel.Text = "0,0000 мм";
			this.ringDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.settingsTabPage);
			this.mainTabControl.Controls.Add(this.findContourTabPage);
			this.mainTabControl.Controls.Add(this.measurementTabPage);
			this.mainTabControl.Controls.Add(this.calibrationTabPage);
			this.mainTabControl.Location = new System.Drawing.Point(498, 12);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(332, 360);
			this.mainTabControl.TabIndex = 3;
			this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(62, 251);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(119, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "Множитель поправки:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(66, 277);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(115, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "Смещение поправки:";
			// 
			// correctionMultiplierTextBox
			// 
			this.correctionMultiplierTextBox.Location = new System.Drawing.Point(187, 248);
			this.correctionMultiplierTextBox.Name = "correctionMultiplierTextBox";
			this.correctionMultiplierTextBox.Size = new System.Drawing.Size(60, 20);
			this.correctionMultiplierTextBox.TabIndex = 7;
			this.correctionMultiplierTextBox.Text = "1.0000";
			// 
			// correctionOffsetTextBox
			// 
			this.correctionOffsetTextBox.Location = new System.Drawing.Point(187, 274);
			this.correctionOffsetTextBox.Name = "correctionOffsetTextBox";
			this.correctionOffsetTextBox.Size = new System.Drawing.Size(60, 20);
			this.correctionOffsetTextBox.TabIndex = 8;
			this.correctionOffsetTextBox.Text = "0.0000";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(253, 277);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(23, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "мм";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 384);
			this.Controls.Add(this.mainTabControl);
			this.Controls.Add(this.videoPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "RingMeter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).EndInit();
			this.calibrationTabPage.ResumeLayout(false);
			this.calibrationTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxIterationNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCornersInColNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCornersInRowNumericUpDown)).EndInit();
			this.findContourTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rainbowLine1)).EndInit();
			this.settingsTabPage.ResumeLayout(false);
			this.settingsTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumFramesNumericUpDown)).EndInit();
			this.measurementTabPage.ResumeLayout(false);
			this.measurementTabPage.PerformLayout();
			this.mainTabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox videoPictureBox;
		private System.Windows.Forms.TabPage calibrationTabPage;
		private System.Windows.Forms.NumericUpDown maxIterationNumericUpDown;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox cellSizeTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button calibrateButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numCornersInColNumericUpDown;
		private System.Windows.Forms.NumericUpDown numCornersInRowNumericUpDown;
		private System.Windows.Forms.TabPage findContourTabPage;
		private CustomConrols.RainbowLine rainbowLine1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private CustomConrols.RangeTrackBar ValueRangeTrackBar;
		private CustomConrols.RangeTrackBar SaturationRangeTrackBar;
		private CustomConrols.RangeTrackBar HueRangeTrackBar;
		private System.Windows.Forms.TabPage settingsTabPage;
		private System.Windows.Forms.ComboBox webCamFrameSizeComboBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button StopCameraButton;
		private System.Windows.Forms.Button StartCameraButton;
		private System.Windows.Forms.ComboBox webCamChoiceComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button WebCameraSettingsButton;
		private System.Windows.Forms.Label FramesNumberLabel;
		private System.Windows.Forms.NumericUpDown NumFramesNumericUpDown;
		private CustomConrols.HelpLink NumFramesHelpLink;
		private System.Windows.Forms.TabPage measurementTabPage;
		private System.Windows.Forms.TabControl mainTabControl;
		private CustomConrols.HelpLink helpLink1;
		private System.Windows.Forms.Label ringDiameterLabel;
		private CustomConrols.HelpLink helpLink2;
		private System.Windows.Forms.CheckBox useUndistortCheckBox;
		private System.Windows.Forms.TextBox correctionOffsetTextBox;
		private System.Windows.Forms.TextBox correctionMultiplierTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
	}
}

