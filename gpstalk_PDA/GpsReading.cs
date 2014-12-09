using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Represents a GpsReading. Useful for parsing and writing NMEA data.
	/// </summary>
	/// <remarks>
	/// see http://aprs.gids.nl/nmea/ for NMEA specification
	/// </remarks>
	public class GpsReading
	{
		//=======================================================================
		#region -= properties =-

		/// <summary>
		/// Fixed GPS Data
		/// </summary>
		public GgaData FixedGpsData
		{
			get { return this._fixedGpsData; }
			set { this._fixedGpsData = value; }
		}
		protected GgaData _fixedGpsData = new GgaData();
		/// <summary>
		/// DOP and Active Satellite Data
		/// </summary>
		public GsaData DopActiveSatellites
		{
			get { return this._dopActiveSatellites; }
			set { this._dopActiveSatellites = value; }
		}
		protected GsaData _dopActiveSatellites = new GsaData();
		
		/// <summary>
		/// Satellites in View Data
		/// TODO: because the gps gives you several messages, each with 4 satellites, we should aggregate them
		/// </summary>
		public List<GsvData> SatellitesInView
		{
			get { return this._satellitesInView; }
			set { this._satellitesInView = value; }
		}
		protected List<GsvData> _satellitesInView = new List<GsvData>();
		
		/// <summary>
		/// Signal Strength Data
		/// </summary>
		public MssData SignalStrength
		{
			get { return this._signalStrength; }
			set { this._signalStrength = value; }
		}
		protected MssData _signalStrength = new MssData();
		
		/// <summary>
		/// Recommended Minimum GPS Data
		/// </summary>
		public RmcData Summary
		{
			get { return this._summary; }
			set { this._summary = value; }
		}
		protected RmcData _summary = new RmcData();
		
		/// <summary>
		/// Groundspeed and Heading Data
		/// </summary>
		public VtgData GroundVector
		{
			get { return this._groundVector; }
			set { this._groundVector = value; }
		}
		protected VtgData _groundVector = new VtgData();

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= constructors =-

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= public methods =-

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= static methods =-

		//=======================================================================
		public static GpsReading Parse(List<string> inputStrings)
		{
			//---- declare vars
			GpsReading gpsReading;
			string[] sentences = new string[inputStrings.Count];

			//---- copy our strings into an array	
			inputStrings.CopyTo(sentences);

			//---- parse 'em
			gpsReading = ParseSentences(sentences);

			//---- return
			return gpsReading;
		}
		//=======================================================================

		//=======================================================================
		public static GpsReading Parse(string inputString)
		{
			//---- declare vars
			GpsReading gpsReading;
			string[] sentences = inputString.Split(new char[] { '\r', '\n' });

			//---- parse 'em
			gpsReading = ParseSentences(sentences);

			//---- return
			return gpsReading;
		}
		//=======================================================================

		//=======================================================================
		private static GpsReading ParseSentences(string[] sentences)
		{
			//---- declare vars
			GpsReading gpsReading = new GpsReading();

			//---- loop through each sentence
			for (int i = 0; i < sentences.Length; i++)
			{
				//---- if the sentence has a header and data
				if (sentences[i].Length > 6)
				{
					switch (sentences[i].Trim().Substring(0, 6).ToUpper())
					{
						case "$GPGSA":
							gpsReading.DopActiveSatellites = GsaData.Parse(sentences[i]);
							break;
						case "$GPGSV":
							gpsReading.SatellitesInView.Add(GsvData.Parse(sentences[i]));
							break;
						case "$GPGGA":
							gpsReading.FixedGpsData = GgaData.Parse(sentences[i]);
							break;
						case "$GPRMC":
							gpsReading.Summary = RmcData.Parse(sentences[i]);
							break;
						case "$GPMSS":
							break;
						case "$GPVTG":
							break;
					}
				}
			}

			//---- return our parsed gps reading
			return gpsReading;
		}
		//=======================================================================

		#endregion
		//=======================================================================


	}
	//=======================================================================
}
