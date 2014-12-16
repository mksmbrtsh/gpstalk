using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Ground speed and course data
	/// </summary>
	public class VtgData
	{
		/// <summary>
		/// Heading, from true north, in degrees
		/// </summary>
		public decimal TrueHeading
		{
			get { return this._trueHeading; }
			set { this._trueHeading = value; }
		}
		protected decimal _trueHeading;
		
		/// <summary>
		/// Heading, from magnetic north, in degrees
		/// </summary>
		public decimal MagneticHeading
		{
			get { return this._magneticHeading; }
			set { this._magneticHeading = value; }
		}
		protected decimal _magneticHeading;
		
		/// <summary>
		/// Velocity of travel over the ground in knots
		/// </summary>
		public decimal GroundSpeedInKnots
		{
			get { return this._groundSpeedInKnots; }
			set { this._groundSpeedInKnots = value; }
		}
		protected decimal _groundSpeedInKnots;
		
		/// <summary>
		/// Velocity of travel over the ground in Kilometers per Hour (KMH)
		/// </summary>
		public decimal GroundSpeedInKmh
		{
			get { return this._groundSpeedInKmh; }
			set { this._groundSpeedInKmh = value; }
		}
		protected decimal _groundSpeedInKmh;
		
		/// <summary>
		/// 
		/// </summary>
		public GpsMode Mode
		{
			get { return this._mode; }
			set { this._mode = value; }
		}
		protected GpsMode _mode;
		
		/// <summary>
		/// 
		/// </summary>
		public int CheckSum
		{
			get { return this._checkSum; }
			set { this._checkSum = value; }
		}
		protected int _checkSum;
	}
	//=======================================================================
}
