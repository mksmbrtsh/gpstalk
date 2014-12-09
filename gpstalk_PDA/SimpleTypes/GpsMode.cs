using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// The mode of the gps
	/// </summary>
	public enum GpsMode
	{
		/// <summary>
		/// 
		/// </summary>
		Autonomous,
		/// <summary>
		/// Enhanced GPS that uses ground-based stations to counteract the added signal noise to give better positioning data
		/// </summary>
		DifferentialGPS,
		/// <summary>
		/// 
		/// </summary>
		DR
	}
	//=======================================================================
}
