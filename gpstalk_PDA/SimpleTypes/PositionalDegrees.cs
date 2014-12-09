using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Represents a longitudinal or latitudinal position in Degrees, Minutes, and Seconds.
	/// </summary>
	public class PositionalDegree
	{
		//=======================================================================
		#region -= properties =-

		public Direction Direction
		{
			get { return this._direction; }
			set { this._direction = value; }
		}
		protected Direction _direction;
		//public int Degrees
		//{
		//    get { return this._degrees; }
		//    set { this._degrees = value; }
		//}
		//protected int _degrees;
		//public int Minutes
		//{
		//    get { return this._minutes; }
		//    set { this._minutes = value; }
		//}
		//protected int _minutes;
		//public int Seconds
		//{
		//    get { return this._seconds; }
		//    set { this._seconds = value; }
		//}
		//protected int _seconds;

		public decimal Degrees
		{
			get { return this._degrees; }
			set { this._degrees = value; }
		}
		protected decimal _degrees;

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= constructors =-

		public PositionalDegree() { }

		//public PositionalDegree(int degrees, int minutes, int seconds)
		//    : base()
		//{
		//    this._degrees = degrees;
		//    this._minutes = minutes;
		//    this._seconds = seconds;
		//}

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= public methods =-

		//=======================================================================
		/// <summary>
		/// Returns in the format of "23908.908,N"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this._degrees.ToString() + "," + DirectionUtil.ToString(this._direction);
		}
		//=======================================================================

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= static methods =-

		/// <summary>
		/// must be in the format 24952.32,N
		/// </summary>
		/// <param name="positionalDegree"></param>
		/// <returns></returns>
		public static PositionalDegree Parse(string inputString)
		{
			//---- declare vars
			PositionalDegree position = new PositionalDegree();

			//---- split it in half
			string[] halves = inputString.Trim().Split(',');
			//----
			if(halves.Length < 2) { throw new FormatException("Input string must be in the format 23490.32,N"); }

			//---- parse the direction
			position.Direction = DirectionUtil.Parse(halves[1]);

			//---- parse the degrees, minutes seconds
			decimal degrees;

            bool isparse = true;
            try
            {
                degrees = decimal.Parse(halves[0]);
            }
            catch (ArgumentException)
            {
                isparse = false;
                degrees = new decimal();
            }

            if (isparse)
			{ position.Degrees = degrees; }
			else { throw new FormatException("Degrees must be in the format 20934.23"); }

			//----
			return position;
		}

		public static bool TryParse(string inputString, out PositionalDegree positionalDegree)
		{
			try
			{
				positionalDegree = Parse(inputString);
				return true;
			}
			catch(Exception)
			{
				positionalDegree = null;
				return false;
			}
		}

		#endregion
		//=======================================================================

	}
}
