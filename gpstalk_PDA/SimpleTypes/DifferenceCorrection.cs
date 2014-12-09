using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Represents a DGPS correction
	/// </summary>
	public class DifferenceCorrection
	{

		/// <summary>
		/// Age, in seconds, of the DGPS correction
		/// </summary>
		public decimal Age
		{
			get { return this._age; }
			set { this._age = value; }
		}
		protected decimal _age;
		/// <summary>
		/// The DGPS station identifier
		/// </summary>
		public int StationID
		{
			get { return this._stationID; }
			set { this._stationID = value; }
		}
		protected int _stationID;

	}
	//=======================================================================
}
