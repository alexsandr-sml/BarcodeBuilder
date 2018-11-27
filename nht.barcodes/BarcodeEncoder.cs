﻿using nht.barcodes._1D;
using nht.barcodes.Common;
using nht.barcodes.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace nht.barcodes
{
    public class BarcodeEncoder
    {
        public BarcodeEncoder()
        {

        }

        public static BarcodeResult Encode(BarcodeInfo info)
        {
            switch(info.TypeBarcode)
            {
                case EBarcodeFormats.EAN13:
                    var ean13 = new Ean13();
                    return ean13.Encode(info);
                default:
                    throw new Exception("Not implemented");
                    
            }
        }

    }
}
