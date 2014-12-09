About
=
a c# library for parsing and writing NMEA GPS data.
This is a fork [gpstalk](https://code.google.com/p/gpstalk/) project.

(update: added GPGSA Parsing 2009.02.13)
Build
=
CompactFramework 2.0, c# 2.0 and more.

General
=
Parses raw NMEA GPS data and loads it into an OOP library.

Originally built so that I could read GPS data from a robot with a GPS component in it.

Currently parses the following NMEA sentences:

- **GPGGA** - Fixed GPS Data
- **GPGSV** - Satellites in View Data
- **GPRMC** - Recommended Minimum GPS Data
- **GPGSA** - DOP and Active Satellies (Added 2009.02.13)
Other sentence support to follow. You can also add it yourself, very easily, just look at the other NMEA sentences. If you'd like me to add a specific sentence parsing, drop me a line at b at wowzer dot net. it only takes 30 minutes or so to add an test a new sentence parser.

To use, reference the DLL, and then:
```
  GpsReading gpsReading = GpsReading.Parse("[Raw NMEA Data]");
```
Sentence mappings are:

**GPRMC**:
```
  gpsReading.Summary
  ```
**GPGGA**:
```
  gpsReading.FixedGpsData
  ```
**GPGSV**:
```
  gpsReading.SatellitesInView
  ```
**GPGSA**:
```
  gpsReading.DopActiveSatellites
```
Stream use
=
here's some sample code if you're reading the sentences from a stream (e.g. direct from a serial port).

serial event listener (listens for serial data incoming, and adds it to a stringbuilder buffer):
```
//=========================================================================
protected void GpsRobot_SerialDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
{
        //---- buffer the response
        this._responseBuffer.Append(this._serialPort.ReadExisting());

        //---- the minimum sentence size is 14 characters, so if our buffer is at least that big, lets 
        // try and parse the sentences
        if (this._responseBuffer.Length > 14)
        { this.ParseSentences(); }
}
//=========================================================================
Parser (loops through until it finds a complete set of sentences, parses them, bubbles them up and then clears them out of the buffer so they don't get parsed again):

//=========================================================================
protected void ParseSentences()
{
        //---- declare vars
        int sentenceStartIndex = -1;
        int sentenceEndIndex = 0;
        int sentenceLength = 0;

        //---- see if we can find an entire NMEA sentence (starts with '$', ends with line feed)
        for (int i = 0; i < this._responseBuffer.Length; i++)
        {
                //---- if we found a NMEA sentence start
                if (this._responseBuffer[i] == '$')
                { sentenceStartIndex = i; }

                //---- if we found the end of the sentence
                if (sentenceStartIndex > -1 && this._responseBuffer[i] == '\r')
                {
                        //---- get the end index and compute the length
                        sentenceEndIndex = i;
                        sentenceLength = sentenceEndIndex - sentenceStartIndex;
                        
                        //---- copy the sentence 
                        char[] sentenceChars = new char[sentenceLength];
                        this._responseBuffer.CopyTo(sentenceStartIndex, sentenceChars, 0, sentenceLength);
                        string sentence = new string(sentenceChars);

                        //---- add the new sentence
                        this._nmeaSentenceBuffer.Add(sentence);

                        //---- if the sentence is $GPRMC
                        if (sentence.StartsWith("$GPRMC"))
                        {
                                //---- raise the event that we've got a complete set of NMEA sentences
                                this.RaiseGpsDataReceivedEventArgs();

                                //---- clear the sentence buffer (cause we're starting over)
                                this._nmeaSentenceBuffer.Clear();
                        }
                        
                        //---- clear the sentence out of the main response buffer (so we don't parse it again)
                        this._responseBuffer.Remove(0, sentenceEndIndex + 1);

                        //---- return out of the for loop
                        return;
                }
        }
}
```
to see this code in action, checkout [robotiTalk](https://code.google.com/p/robotitalk/)

