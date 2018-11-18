using System;

namespace Metrics
{
    // ***************************************************************************************
    // Class Name:	ConvertMetrics.Pixels
    // Date:		July 2009
    // Author:		Milton Neal
    // Function:	Convert between millimeters/inches/pixels for given device resolution(DPI)
    // Contact:		miltonneal@bigpond.com
    // **************************************************************************************** 
    public abstract class Convert
    {
        private const float millimetersPerInch = 25.4f; // 25.4 millimeter per inch

        public static float MillimetersToPixels(float millimeter, float dpi)
        {
            return (millimeter / millimetersPerInch) * dpi;
        }

        public static float InchesToPixels(float inch, float dpi)
        {
            return inch * dpi;
        }

        public static float PixelsToMillimeter(float pixels, float dpi)
        {
            return (pixels / dpi) * millimetersPerInch;
        }

        public static float PixelsToInch(float pixels, float dpi)
        {
            return pixels / dpi;
        }
    };
}