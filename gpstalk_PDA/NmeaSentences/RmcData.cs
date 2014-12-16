using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Recommended minimum data
	/// </summary>
	public class RmcData
	{
		/*
		Recommended minimum specific GPS/Transit data

		eg1. $GPRMC,081836,A,3751.65,S,14507.36,E,000.0,360.0,130998,011.3,E*62
		eg2. $GPRMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68


				   225446       Time of fix 22:54:46 UTC
				   A            Navigation receiver warning A = OK, V = warning
				   4916.45,N    Latitude 49 deg. 16.45 min North
				   12311.12,W   Longitude 123 deg. 11.12 min West
				   000.5        Speed over ground, Knots
				   054.7        Course Made Good, True
				   191194       Date of fix  19 November 1994
				   020.3,E      Magnetic variation 20.3 deg East
				   *68          mandatory checksum


		eg3. $GPRMC,220516,A,5133.82,N,00042.24,W,173.8,231.8,130694,004.2,W*70
					  1    2    3    4    5     6    7    8      9     10  11 12


			  1   220516     Time Stamp
			  2   A          validity - A-ok, V-invalid
			  3   5133.82    current Latitude
			  4   N          North/South
			  5   00042.24   current Longitude
			  6   W          East/West
			  7   173.8      Speed in knots
			  8   231.8      True course
			  9   130694     Date Stamp
			  10  004.2      Variation
			  11  W          East/West
			  12  *70        checksum


		eg4. $GPRMC,hhmmss.ss,A,llll.ll,a,yyyyy.yy,a,x.x,x.x,ddmmyy,x.x,a*hh
		1    = UTC of position fix
		2    = Data status (V=navigation receiver warning)
		3    = Latitude of fix
		4    = N or S
		5    = Longitude of fix
		6    = E or W
		7    = Speed over ground in knots
		8    = Track made good in degrees True
		9    = UT date
		10   = Magnetic variation degrees (Easterly var. subtracts from true course)
		11   = E or W
		12   = Checksum	
		*/

		//=======================================================================
		#region -= properties =-

		public DateTime UtcDateTime
		{
			get { return this._utcDateTime; }
			set { this._utcDateTime = value; }
		}
		protected DateTime _utcDateTime;
		
		public Status Status
		{
			get { return this._status; }
			set { this._status = value; }
		}
		protected Status _status;
		
		public Position Position
		{
			get { return this._position; }
			set { this._position = value; }
		}
		protected Position _position = new Position();
		
		/// <summary>
		/// Speed over the ground in knots
		/// </summary>
		public decimal GroundSpeed
		{
			get { return this._groundSpeed; }
			set { this._groundSpeed = value; }
		}
		protected decimal _groundSpeed;
		
		public decimal Heading
		{
			get { return this._heading; }
			set { this._heading = value; }
		}
		protected decimal _heading;

		public MagneticVariation MagneticVariation
		{
			get { return this._magneticVariation; }
			set { this._magneticVariation = value; }
		}
		protected MagneticVariation _magneticVariation = new MagneticVariation();

		public int CheckSum
		{
			get { return this._checkSum; }
			set { this._checkSum = value; }
		}
		protected int _checkSum;

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= constructors =-

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= public methods =- 

		#endregion
		//=======================================================================

		//=======================================================================
		#region -= static methods =-

		public static RmcData Parse(string inputString)
		{
			//---- declare vars
			RmcData rmcData = new RmcData();
			string dataString = inputString.Substring(0, inputString.IndexOf('*')); // strip off the checksum
			string[] values = dataString.Split(',');
			
			//---- if we don't have 12 (header + 11), it's no good
			if(values.Length < 12)
			{ throw new FormatException(); }
			
			//---- Status
			if(values[2].ToUpper() == "A") 
			{ rmcData.Status = Status.Valid; }
			else { rmcData.Status = Status.Invalid;}

            if (rmcData.Status == Status.Invalid)
                return rmcData;
			
			if (values[1].Length == 6 && values[9].Length == 6)
            {//---- if the date and time both are six digits
				//---- make sure that they're actually numbers
				int temp;
                bool isparse = true;
                try
                {
                    temp = int.Parse(values[1]);
                    temp = int.Parse(values[9]);
                    
                }
                catch (ArgumentException)
                {
                    isparse = false;
                }
                if (isparse)
				{
					//---- should add more validation here
					int day = int.Parse(values[9].Substring(0, 2));
					int month = int.Parse(values[9].Substring(2, 2));
					int year = int.Parse(values[9].Substring(4, 2));
					int hour = int.Parse(values[1].Substring(0, 2));
					int minute = int.Parse(values[1].Substring(2, 2));
					int second = int.Parse(values[1].Substring(4, 2));

					rmcData.UtcDateTime = new DateTime(year, month, day, hour, minute, second);
				}
				else { throw new FormatException("Date or time string is invalid"); }
			}
            else if (values[1].Length == 10 && values[9].Length == 6)
            {//---- if the date and time both are six digits
                //---- make sure that they're actually numbers
                int temp;
                double timeTemp;
                bool isparse = true;
                try
                {
                    timeTemp = double.Parse(values[1]);
                    temp = int.Parse(values[9]);

                }
                catch (ArgumentException)
                {
                    isparse = false;
                }
                if (isparse)
                {
                    //---- should add more validation here
                    int day = int.Parse(values[9].Substring(0, 2));
                    int month = int.Parse(values[9].Substring(2, 2));
                    int year = int.Parse(values[9].Substring(4, 2));
                    int hour = int.Parse(values[1].Substring(0, 2));
                    int minute = int.Parse(values[1].Substring(2, 2));
                    int second = int.Parse(values[1].Substring(4, 2));
                    int millisecond = int.Parse(values[1].Substring(7, 3));
                    rmcData.UtcDateTime = new DateTime(year, month, day, hour, minute, second);
                }
                else { throw new FormatException("Date or time string is invalid"); }
            }
            else
            
            
            { throw new FormatException("Date or time string is invalid"); }

			//---- lat/long position
			rmcData.Position = Position.Parse(values[3] + "," + values[4] + ";" + values[5] + "," + values[6]);

			//---- speed in knots
			rmcData.GroundSpeed = Decimal.Parse(values[7]);

			//---- true course
			rmcData.Heading = Decimal.Parse(values[8]);

			//---- magnetic declination
			rmcData.MagneticVariation = MagneticVariation.Parse(values[10] + "," + values[11]);

			//---- return
			return rmcData;

			//1   220516     Time Stamp
			//2   A          validity - A-ok, V-invalid
			//3   5133.82    current Latitude
			//4   N          North/South
			//5   00042.24   current Longitude
			//6   W          East/West
			//7   173.8      Speed in knots
			//8   231.8      True course
			//9   130694     Date Stamp
			//10  004.2      Variation
			//11  W          East/West
			//12  *70        checksum


		}

		public static bool TryParse(string rawNmeaRmcString, out RmcData rmcData)
		{
			try
			{
				rmcData = Parse(rawNmeaRmcString);
				return true;
			}
			catch
			{
				rmcData = null;
				return false;
			}
		}

		#endregion
		//=======================================================================


	}
	//=======================================================================
}
