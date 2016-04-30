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

namespace RingMeter
{
	class MainFormStateObserver
	{
		public enum FormState
		{
			WebCamNotChosen = 1,
			WebCamChosen,
			Settings,
			FindContour,
			Measurement,
			Calibration,
		}

		private FormState state;
		public delegate bool ChangeCallbackDelegate(FormState oldState, FormState newState);
		public event ChangeCallbackDelegate ChangeStateEvent;

		public FormState State
		{
			get
			{
				return state;
			}

			set
			{
				if (ChangeStateEvent != null && ChangeStateEvent(state, value)) state = value;
			}
		}
	}
}
