using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Geoidal separation (Diff. between WGS-84 earth ellipsoid and mean sea level. '-' = geoid is below WGS-84 ellipsoid)
	/// </summary>
	public class GeoidalSeparation
	{

		public decimal Difference
		{
			get { return this._difference; }
			set { this._difference = value; }
		}
		protected decimal _difference;
		public UnitType UnitType
		{
			get { return this._unitType; }
			set { this._unitType = value; }
		}
		protected UnitType _unitType;

		//=======================================================================
		#region -= static methods =-

		/// <summary>
		/// Must be in the format -398.2,M	
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static GeoidalSeparation Parse(string inputString)
		{
			//---- declare vars
			GeoidalSeparation geoidal = new GeoidalSeparation();

			//---- split it in half
			string[] halves = inputString.Trim().Split(',');
			//----
			if (halves.Length < 2) { throw new FormatException("Input string must be in the format -3569.2,M"); }

			//---- parse the difference
			geoidal.Difference = decimal.Parse(halves[0]);

			//---- parse the units (should always be meters)
			geoidal.UnitType = UnitTypeUtil.Parse(halves[1]);

			//----
			return geoidal;
		}

		public static bool TryParse(string inputString, out GeoidalSeparation geoidalSeparation)
		{
			try
			{
				geoidalSeparation = Parse(inputString);
				return true;
			}
			catch (Exception)
			{
				geoidalSeparation = null;
				return false;
			}
		}

		#endregion
		//=======================================================================


	}
	//=======================================================================
}
