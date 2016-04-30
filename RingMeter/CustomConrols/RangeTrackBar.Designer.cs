namespace RingMeter.CustomConrols
{
	partial class RangeTrackBar
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.MinNameLabel = new System.Windows.Forms.Label();
			this.MinTrackBar = new System.Windows.Forms.TrackBar();
			this.MinValueLabel = new System.Windows.Forms.Label();
			this.MaxValueLabel = new System.Windows.Forms.Label();
			this.MaxTrackBar = new System.Windows.Forms.TrackBar();
			this.MaxNameLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MinTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// MinNameLabel
			// 
			this.MinNameLabel.AutoSize = true;
			this.MinNameLabel.Location = new System.Drawing.Point(3, 9);
			this.MinNameLabel.Name = "MinNameLabel";
			this.MinNameLabel.Size = new System.Drawing.Size(35, 13);
			this.MinNameLabel.TabIndex = 0;
			this.MinNameLabel.Text = "Name";
			this.MinNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MinTrackBar
			// 
			this.MinTrackBar.Location = new System.Drawing.Point(35, 7);
			this.MinTrackBar.Maximum = 1000;
			this.MinTrackBar.Name = "MinTrackBar";
			this.MinTrackBar.Size = new System.Drawing.Size(239, 45);
			this.MinTrackBar.TabIndex = 1;
			this.MinTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.MinTrackBar.ValueChanged += new System.EventHandler(this.MainTrackBar_ValueChanged);
			// 
			// MinValueLabel
			// 
			this.MinValueLabel.AutoSize = true;
			this.MinValueLabel.Location = new System.Drawing.Point(278, 9);
			this.MinValueLabel.Name = "MinValueLabel";
			this.MinValueLabel.Size = new System.Drawing.Size(34, 13);
			this.MinValueLabel.TabIndex = 2;
			this.MinValueLabel.Text = "Value";
			this.MinValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValueLabel
			// 
			this.MaxValueLabel.AutoSize = true;
			this.MaxValueLabel.Location = new System.Drawing.Point(278, 43);
			this.MaxValueLabel.Name = "MaxValueLabel";
			this.MaxValueLabel.Size = new System.Drawing.Size(34, 13);
			this.MaxValueLabel.TabIndex = 5;
			this.MaxValueLabel.Text = "Value";
			this.MaxValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxTrackBar
			// 
			this.MaxTrackBar.Location = new System.Drawing.Point(35, 41);
			this.MaxTrackBar.Maximum = 1000;
			this.MaxTrackBar.Name = "MaxTrackBar";
			this.MaxTrackBar.Size = new System.Drawing.Size(239, 45);
			this.MaxTrackBar.TabIndex = 4;
			this.MaxTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.MaxTrackBar.ValueChanged += new System.EventHandler(this.MaxTrackBar_ValueChanged);
			// 
			// MaxNameLabel
			// 
			this.MaxNameLabel.AutoSize = true;
			this.MaxNameLabel.Location = new System.Drawing.Point(3, 43);
			this.MaxNameLabel.Name = "MaxNameLabel";
			this.MaxNameLabel.Size = new System.Drawing.Size(35, 13);
			this.MaxNameLabel.TabIndex = 3;
			this.MaxNameLabel.Text = "Name";
			this.MaxNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// RangeTrackBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.MaxValueLabel);
			this.Controls.Add(this.MaxTrackBar);
			this.Controls.Add(this.MaxNameLabel);
			this.Controls.Add(this.MinValueLabel);
			this.Controls.Add(this.MinTrackBar);
			this.Controls.Add(this.MinNameLabel);
			this.Name = "RangeTrackBar";
			this.Size = new System.Drawing.Size(317, 69);
			((System.ComponentModel.ISupportInitialize)(this.MinTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxTrackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TrackBar MinTrackBar;
		public System.Windows.Forms.Label MinValueLabel;
		public System.Windows.Forms.Label MinNameLabel;
		public System.Windows.Forms.Label MaxValueLabel;
		public System.Windows.Forms.TrackBar MaxTrackBar;
		public System.Windows.Forms.Label MaxNameLabel;

	}
}
