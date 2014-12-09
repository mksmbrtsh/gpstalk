using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Cardinal Directions
	/// </summary>
	public enum Direction
	{
		North
		,South
		,East
		,West
		,Empty
	}
	//=======================================================================

	public static class DirectionUtil
	{
		public static Direction Parse(string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{ return Direction.Empty; }

			switch (inputString.ToUpper())
			{
				case "N":
					return Direction.North;
				case "S":
					return Direction.South;
				case "E":
					return Direction.East;
				case "W":
					return Direction.West;
				default:
					throw new FormatException("Direction must be N, S, E, or W.");
			}
		}

		/// <summary>
		/// returns "N", "S", "E", "W", or ""
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		public static string ToString(Direction direction)
		{
			switch (direction)
			{
				case Direction.North:
					return "N";
				case Direction.South:
					return "S";
				case Direction.East:
					return "E";
				case Direction.West:
					return "W";
				case Direction.Empty:
					return "";
				default:
					throw new Exception("what?");
			}
		}
	}
}
