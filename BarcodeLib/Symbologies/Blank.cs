using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeLib.Symbologies
{
    /// <summary>
    ///  Blank encoding template
    ///  Written by: Brad Barnhill
    /// </summary>
    class Blank : BarcodeCommon, IBarcode
    {
        public string Encoded_Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}
