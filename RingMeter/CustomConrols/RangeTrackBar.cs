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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RingMeter.CustomConrols
{

	public partial class RangeTrackBar : UserControl
	{
		public int TopValue
		{
			get
			{
				return MinTrackBar.Maximum;
			}

			set
			{
				MinTrackBar.Maximum = value;
				MaxTrackBar.Maximum = value;
			}
		}

		public int BottomValue
		{
			get
			{
				return MinTrackBar.Minimum;
			}

			set
			{
				MinTrackBar.Minimum = value;
				MaxTrackBar.Minimum = value;
			}
		}

		public int MinValue
		{
			get
			{
				return MinTrackBar.Value;
			}

			set
			{
				MinTrackBar.Value = value;
			}
		}

		public string MinText
		{
			get
			{
				return MinNameLabel.Text;
			}

			set
			{
				MinNameLabel.Text = value;
			}
		}

		public int MaxValue
		{
			get
			{
				return MaxTrackBar.Value;
			}

			set
			{
				MaxTrackBar.Value = value;
			}
		}

		public string MaxText
		{
			get
			{
				return MaxNameLabel.Text;
			}

			set
			{
				MaxNameLabel.Text = value;
			}
		}

		public RangeTrackBar()
		{
			InitializeComponent();
			MinValueLabel.Text = MinTrackBar.Value.ToString();
			MaxValueLabel.Text = MaxTrackBar.Value.ToString();
		}

		private void MainTrackBar_ValueChanged(object sender, EventArgs e)
		{
			MinValueLabel.Text = MinTrackBar.Value.ToString();
		}

		private void MaxTrackBar_ValueChanged(object sender, EventArgs e)
		{
			MaxValueLabel.Text = MaxTrackBar.Value.ToString();
		}
	}
}
