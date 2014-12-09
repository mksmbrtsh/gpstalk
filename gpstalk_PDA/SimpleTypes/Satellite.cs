using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	public class Satellite
	{
		/// <summary>
		/// Satellite PRN number
		/// </summary>
		public int ID
		{
			get { return this._id; }
			set { this._id = value; }
		}
		protected int _id;

		/// <summary>
		/// Whether or not the satellite was used in the positional fix
		/// </summary>
		public bool UsedInPositionFix
		{
			get { return this._usedInPositionFix; }
			set { this._usedInPositionFix = value; }
		}
		protected bool _usedInPositionFix;
		
		/// <summary>
		/// The angle of the satellite degrees, 0-90
		/// </summary>
		public int AngleOfElvation
		{
			get { return this._angleOfElvation; }
			set { this._angleOfElvation = value; }
		}
		protected int _angleOfElvation;

		/// <summary>
		/// The azimuth of the satellite, in degrees, from true north. 0-359.
		/// </summary>
		public int Azimuth
		{
			get { return this._azimuth; }
			set { this._azimuth = value; }
		}
		protected int _azimuth;
		
		/// <summary>
		/// Signal strength, in decibels. 0-99.
		/// </summary>
		public int SignalStrength
		{
			get { return this._signalStrength; }
			set { this._signalStrength = value; }
		}
		protected int _signalStrength;
	}
	//=======================================================================
}
