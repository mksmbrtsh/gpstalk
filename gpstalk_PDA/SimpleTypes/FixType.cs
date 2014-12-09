using System;
using System.Collections.Generic;

using System.Text;

namespace Sicily.Gps
{
	//=======================================================================
	public enum FixType : int
	{
		NotAvailable = 0,
		TwoDimensional = 2,
		ThreeDimensional = 3,
	}
	//=======================================================================

	////=======================================================================
	//public static class FixTypeUtil
	//{
	//    public static FixType Parse(string inputString)
	//    {
	//        if (string.IsNullOrEmpty(inputString))
	//        { return FixType.NotAvailable; }

	//        switch (inputString)
	//        {
	//            case "0":
	//                return FixType.NotAvailable;
	//            case "2":
	//                return FixType.TwoDimensional;
	//            case "3":
	//                return FixType.ThreeDimensional;
	//            default:
	//                return FixType.NotAvailable;
	//        }
	//    }

	//    public static string ToString(FixType fixType)
	//    {
	//        switch (fixType)
	//        {
	//            case FixType.NotAvailable:
	//                return "0";
	//            case FixType.TwoDimensional:
	//                return "2";
	//            case FixType.ThreeDimensional:
	//                return "3";
	//            default:
	//                return "";
	//        }
	//    }
	//}
	////=======================================================================

}
