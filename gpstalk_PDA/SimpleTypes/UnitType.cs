using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	public enum UnitType
	{
		Meters
		,UnknownType
	}
	//=======================================================================

	//=======================================================================
	public static class UnitTypeUtil
	{
		public static UnitType Parse(string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{ return UnitType.UnknownType; }

			switch (inputString.ToUpper())
			{
				case "M":
					return UnitType.Meters;
				default:
					return UnitType.UnknownType;
			}
		}

		public static string ToString(UnitType unitType)
		{
			switch (unitType)
			{
				case UnitType.Meters:
					return "M";
				default:
					return "";
			}
		}
	}
	//=======================================================================
}
