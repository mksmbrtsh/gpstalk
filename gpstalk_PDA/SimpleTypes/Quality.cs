using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// GPS Quality Indicator
	/// </summary>
	public enum Quality : int
	{
		Invalid = 0,
		Fix = 1,
		Differential = 2,
		Sensitive = 3
	}
	//=======================================================================
}
