using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// 
	/// </summary>
	public enum FixMode
	{
		/// <summary>
		/// forced to operate in 2D or 3D
		/// </summary>
		Manual,
		/// <summary>
		/// 3D/2D
		/// </summary>
		Automatic,
		Unknown
	}
	//=======================================================================

	//=======================================================================
	public static class FixModeUtil
	{
		public static FixMode Parse(string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{ return FixMode.Unknown; }

			switch (inputString.ToUpper())
			{
				case "M":
					return FixMode.Manual;
				case "A":
					return FixMode.Automatic;
				default:
					return FixMode.Unknown;
			}
		}

		public static string ToString(FixMode fixMode)
		{
			switch (fixMode)
			{
				case FixMode.Manual:
					return "M";
				case FixMode.Automatic:
					return "A";
				default:
					return "";
			}
		}
	}
	//=======================================================================
}
