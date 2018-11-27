using nht.barcodes.Common;
using nht.barcodes.Common.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace nht.barcodes.test
{
    public class BarcodeEncoderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Encode()
        {
            var info = new BarcodeInfo()
            {
                Data = "460123456789",
                Angle = 0,
                Height = 250,
                Width = 700,
                IsAddSign = true,
                TypeBarcode = EBarcodeFormats.EAN13
            };

            var actual = BarcodeEncoder.Encode(info);

            actual.Image.Save("test.bmp");
        }
    }
}
