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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RingMeter.CustomConrols
{
	public partial class HelpLink : LinkLabel
	{
		private string helpText;
		public string HelpText
		{
			get
			{
				return helpText; 
			}

			set
			{
				helpText = value;
			}
		}

		public HelpLink()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		private void HelpLink_Click(object sender, EventArgs e)
		{
			MessageBox.Show(helpText, "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
