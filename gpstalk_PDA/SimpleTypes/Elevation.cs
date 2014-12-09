using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// 
	/// </summary>
	public class Elevation
	{

		public decimal Value
		{
			get { return this._value; }
			set { this._value = value; }
		}
		protected decimal _value;
		public UnitType UnitType
		{
			get { return this._unitType; }
			set { this._unitType = value; }
		}
		protected UnitType _unitType;

		//=======================================================================
		#region -= static methods =-

		/// <summary>
		/// Must be in the format 2398,M	
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static Elevation Parse(string inputString)
		{
			//---- declare vars
			Elevation elevation = new Elevation();

			//---- split it in half
			string[] halves = inputString.Trim().Split(',');
			//----
			if (halves.Length < 2) { throw new FormatException("Input string must be in the format 2398,M"); }

			//---- parse the value
			elevation.Value = decimal.Parse(halves[0]);

			//---- parse the units (should always be meters)
			elevation.UnitType = UnitTypeUtil.Parse(halves[1]);
			
			//----
			return elevation;
		}

		public static bool TryParse(string inputString, out Elevation elevation)
		{
			try
			{
				elevation = Parse(inputString);
				return true;
			}
			catch (Exception)
			{
				elevation = null;
				return false;
			}
		}

		#endregion
		//=======================================================================

	}
	//=======================================================================
}
