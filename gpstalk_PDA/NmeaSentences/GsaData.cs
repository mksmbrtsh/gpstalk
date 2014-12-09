using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// DOP and active satellites
	/// </summary>
	public class GsaData
	{
		/// <summary>
		/// 
		/// </summary>
		public FixMode FixMode
		{
			get { return this._fixMode; }
			set { this._fixMode = value; }
		}
		protected FixMode _fixMode;
		
		/// <summary>
		/// 
		/// </summary>
		public FixType FixType
		{
			get { return this._fixType; }
			set { this._fixType = value; }
		}
		protected FixType _fixType;
		
		/// <summary>
		/// The satelites used, up to 12.
		/// </summary>
		public List<Satellite> SatellitesUsed
		{
			get { return this._satellitesUsed; }
			set { this._satellitesUsed = value; }
		}
		protected List<Satellite> _satellitesUsed = new List<Satellite>();
		
		/// <summary>
		/// 
		/// </summary>
		public decimal DilutionOfPrecision
		{
			get { return this._dilutionOfPrecision; }
			set { this._dilutionOfPrecision = value; }
		}
		protected decimal _dilutionOfPrecision;

		/// <summary>
		/// Horizontal dilution of precision 
		/// </summary>
		public decimal HorizontalDilutionOfPrecision
		{
			get { return this._horizontalDilutionOfPrecision; }
			set { this._horizontalDilutionOfPrecision = value; }
		}
		protected decimal _horizontalDilutionOfPrecision;

		/// <summary>
		/// 
		/// </summary>
		public decimal VerticalDilutionOfPrecision
		{
			get { return this._verticalDilutionOfPrecision; }
			set { this._verticalDilutionOfPrecision = value; }
		}
		protected decimal _verticalDilutionOfPrecision;

		//=======================================================================
		#region -= static methods =-

		//=======================================================================
		public static GsaData Parse(string inputString)
		{
			//---- declare vars
			GsaData data = new GsaData();
			string dataString = inputString.Substring(0, inputString.IndexOf('*')); // strip off the checksum
			string[] values = dataString.Split(',');

			//---- if we don't have 18 (header + 17), it's no good
			if (values.Length < 18)
			{ throw new FormatException(); }

			//---- mode
			data.FixMode = FixModeUtil.Parse(values[1]);

			//---- fix type
			data.FixType = (FixType)int.Parse(values[2]);

			//---- loop through the satellites (3-14)
			for (int i = 3; i < 15; i++)
			{
				if (!string.IsNullOrEmpty(values[i]))
				{
					//---- create a new satellite
					Satellite sat = new Satellite();

					//---- these we don't know, so set to -1/false
					sat.AngleOfElvation = -1;
					sat.Azimuth = -1;
					sat.SignalStrength = -1;
					sat.UsedInPositionFix = false;

					//---- get the satellite ID
					sat.ID = int.Parse(values[i]);

					//---- add the sat to the collection
					data.SatellitesUsed.Add(sat);
				}
			}

			//---- PDOP
			data.DilutionOfPrecision = decimal.Parse(values[15]);
			
			//---- HDOP
			data.HorizontalDilutionOfPrecision = decimal.Parse(values[16]);

			//---- VDOP
			data.VerticalDilutionOfPrecision = decimal.Parse(values[17]);

			//---- return
			return data;

			//GPS DOP and active satellites

			//eg1. $GPGSA,A,3,,,,,,16,18,,22,24,,,3.6,2.1,2.2*3C
			//eg2. $GPGSA,A,3,19,28,14,18,27,22,31,39,,,,,1.7,1.0,1.3*35

			//1    = Mode:
			//       M=Manual, forced to operate in 2D or 3D
			//       A=Automatic, 3D/2D
			//2    = Mode:
			//       1=Fix not available
			//       2=2D
			//       3=3D
			//3-14 = IDs of SVs used in position fix (null for unused fields)
			//15   = PDOP
			//16   = HDOP
			//17   = VDOP
		}
		//=======================================================================

		//=======================================================================
		public static bool TryParse(string inputString, out GsaData gsaData)
		{
			try
			{
				gsaData = Parse(inputString);
				return true;
			}
			catch
			{
				gsaData = null;
				return false;
			}
		}
		//=======================================================================



		#endregion
		//=======================================================================


	}
	//=======================================================================
}
