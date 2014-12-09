using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// 
	/// </summary>
	public class MagneticVariation
	{
		/// <summary>
		/// 
		/// </summary>
		public decimal Degrees
		{
			get { return this._degrees; }
			set { this._degrees = value; }
		}
		protected decimal _degrees;
		
		/// <summary>
		/// East or West
		/// </summary>
		public Direction Direction
		{
			get { return this._direction; }
			set { this._direction = value; }
		}
		protected Direction _direction;

		//=======================================================================
		#region -= static methods =-

		/// <summary>
		/// must be in the format 239.02,E
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static MagneticVariation Parse(string inputString)
		{
			//---- declare vars
			MagneticVariation magVar = new MagneticVariation();
			string[] halves = inputString.Split(',');

			if (halves.Length < 2) { throw new FormatException("Input string must be in the format of 33.02,E"); }

			if (string.IsNullOrEmpty(halves[0]))
			{ magVar.Degrees = 0.0M; }
			else
			{ magVar.Degrees = decimal.Parse(halves[0]); }
			magVar.Direction = DirectionUtil.Parse(halves[1]);

			//---- return
			return magVar;
		}

		/// <summary>
		/// must be in the format 239.02,E
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static bool TryParse(string inputString, out MagneticVariation magneticVariation)
		{
			try
			{
				magneticVariation = Parse(inputString);
				return true;
			}
			catch (Exception)
			{
				magneticVariation = null;
				return false;
			}
		}


		#endregion
		//=======================================================================

	}
	//=======================================================================
}
