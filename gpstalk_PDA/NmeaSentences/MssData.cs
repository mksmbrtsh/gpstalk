using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	/// <summary>
	/// Receiver signal Data
	/// </summary>
	public class MssData
	{

		public int SignalStrength
		{
			get { return this._signalStrength; }
			set { this._signalStrength = value; }
		}
		protected int _signalStrength;

		public int SignalToNoiseRatio
		{
			get { return this._signalToNoiseRatio; }
			set { this._signalToNoiseRatio = value; }
		}
		protected int _signalToNoiseRatio;

		public decimal BeaconFrequency
		{
			get { return this._beaconFrequency; }
			set { this._beaconFrequency = value; }
		}
		protected decimal _beaconFrequency;

		public int BeaconBitRate
		{
			get { return this._beaconBitRate; }
			set { this._beaconBitRate = value; }
		}
		protected int _beaconBitRate;

		public int ChannelNumber
		{
			get { return this._channelNumber; }
			set { this._channelNumber = value; }
		}
		protected int _channelNumber;

		public int CheckSum
		{
			get { return this._checkSum; }
			set { this._checkSum = value; }
		}
		protected int _checkSum;

	}
	//=======================================================================
}
