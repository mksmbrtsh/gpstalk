using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Satellites in view
	/// </summary>
	public class GsvData
	{
		/// <summary>
		/// Total number of messages in this cycle
		/// </summary>
		public int MessageCount
		{
			get { return this._messageCount; }
			set { this._messageCount = value; }
		}
		protected int _messageCount;

		/// <summary>
		/// Message number
		/// </summary>
		public int MessageNumber
		{
			get { return this._messageNumber; }
			set { this._messageNumber = value; }
		}
		protected int _messageNumber;

		/// <summary>
		/// Number of satellites in view
		/// </summary>
		public int SatellitesInView
		{
			get { return this._satellitesInView; }
			set { this._satellitesInView = value; }
		}
		protected int _satellitesInView;

		/// <summary>
		/// Satellites
		/// </summary>
		public List<Satellite> Satellites
		{
			get { return this._satellites; }
			set { this._satellites = value; }
		}
		protected List<Satellite> _satellites = new List<Satellite>();


		//=======================================================================
		#region -= static methods =-

		//=======================================================================
		public static GsvData Parse(string inputString)
		{
			//---- declare vars
			GsvData data = new GsvData();
			string dataString = inputString.Substring(0, inputString.IndexOf('*')); // strip off the checksum
			string[] values = dataString.Split(',');

			//---- if we don't have 20 (header + 19), it's no good
			if (values.Length < 20)
			{ throw new FormatException(); }

			//---- number of messages
			data.MessageCount = int.Parse(values[1]);
			
			//---- message number
			data.MessageNumber = int.Parse(values[2]);

			//---- total number of satellites in view
			data.SatellitesInView = int.Parse(values[3]);
			
			//---- loop through the satellites (up to 4)
			for (int i = 0; i < 4; i++)
			{
				//---- create a new satellite
				Satellite sat = new Satellite();

				//---- satellite information starts at index 4, goes for 4 lines, and then starts over (4-7), (8-11), (12-15), (16-19)
				int satIndex = (4 + (4 * i));

				//---- satellite ID
				sat.ID = (string.IsNullOrEmpty(values[satIndex]) ? 0 : int.Parse(values[satIndex]));

				//---- if we got a satellite
				if (sat.ID > 0)
				{
					//---- elevation
					sat.AngleOfElvation = (string.IsNullOrEmpty(values[satIndex + 1]) ? 0 : int.Parse(values[satIndex + 1]));

					//---- azimuth
					sat.Azimuth = (string.IsNullOrEmpty(values[satIndex + 2]) ? 0 : int.Parse(values[satIndex + 2]));

					//---- signal strength
					sat.SignalStrength = (string.IsNullOrEmpty(values[satIndex + 3]) ? 0 : int.Parse(values[satIndex + 3]));

					//---- used in fix? [TODO: Verify this assumption of signal 00 is all right]
					if (sat.SignalStrength > 0)
					{ sat.UsedInPositionFix = true; }
					else { sat.UsedInPositionFix = false; }

					//---- add the sat
					data.Satellites.Add(sat);
				}
			}

			//---- return
			return data;

			//$GPGSV,1,1,13,02,02,213,,03,-3,000,,11,00,121,,14,13,172,05*67
			//1    = Total number of messages of this type in this cycle
			//2    = Message number
			//3    = Total number of SVs in view
			//4    = SV PRN number
			//5    = Elevation in degrees, 90 maximum
			//6    = Azimuth, degrees from true north, 000 to 359
			//7    = SNR, 00-99 dB (null when not tracking)
			//8-11 = Information about second SV, same as field 4-7
			//12-15= Information about third SV, same as field 4-7
			//16-19= Information about fourth SV, same as field 4-7
		}
		//=======================================================================

		//=======================================================================
		public static bool TryParse(string inputString, out GsvData gsvData)
		{
			try
			{
				gsvData = Parse(inputString);
				return true;
			}
			catch
			{
				gsvData = null;
				return false;
			}
		}
		//=======================================================================



		#endregion
		//=======================================================================


	}
	//=======================================================================
}
