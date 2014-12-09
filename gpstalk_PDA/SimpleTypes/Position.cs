using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	public class Position
	{

		/// <summary>
		/// Latitude in PositionalDegrees
		/// </summary>
		public PositionalDegree Latitude
		{
			get { return this._latitude; }
			set { this._latitude = value; }
		}
		protected PositionalDegree _latitude = new PositionalDegree();

		/// <summary>
		/// Longitude in PositionalDegrees
		/// </summary>
		public PositionalDegree Longitude
		{
			get { return this._longitude; }
			set { this._longitude = value; }
		}
		protected PositionalDegree _longitude = new PositionalDegree();


		//=======================================================================
		#region -= public methods =-

		//=======================================================================
		/// <summary>
		/// Returns in the format of "23908.908,W;20987.32,N"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this._latitude.ToString() + ";" + this._longitude.ToString();
		}
		//=======================================================================

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= static methods =-

		/// <summary>
		/// Must be in the format 24952.32,N;45612.85,W
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static Position Parse(string inputString)
		{
			//---- declare vars
			Position position = new Position();
			string[] halves = inputString.Split(';');
			
			if(halves.Length < 2) { throw new FormatException(); }

			position.Latitude = PositionalDegree.Parse(halves[0]);
			position.Longitude = PositionalDegree.Parse(halves[1]);

			//----
			return position;
		}


		/// <summary>
		/// Must be in the format 24952.32,N;45612.85,W
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static bool Parse(string inputString, out Position position)
		{
			try
			{
				position = Parse(inputString);
				return true;
			}
			catch (Exception)
			{
				position = null;
				return false;
			}
		}

		#endregion
		//=======================================================================

	}
	//=======================================================================
}
