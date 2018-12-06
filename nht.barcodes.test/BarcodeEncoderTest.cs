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
        public void EncodeEan13()
        {
            var info = new BarcodeInfo()
            {
                Data = "777777777777",
                Angle = 0,
                Height = 150,
                Width = 200,
                IsAddSign = false,
                TypeBarcode = EBarcodeFormats.EAN13
            };

            var actual = BarcodeEncoder.Encode(info);

            actual.Image.Save("test-ean13.bmp");
        }

        [Test]
        public void EncodeEan8()
        {
            var info = new BarcodeInfo()
            {
                Data = "7777777",
                Angle = 0,
                Height = 100,
                Width = 200,
                IsAddSign = false,
                TypeBarcode = EBarcodeFormats.EAN8
            };

            var actual = BarcodeEncoder.Encode(info);

            actual.Image.Save("test-ean8.bmp");
        }

        [Test]
        public void EncodeEan5()
        {
            var info = new BarcodeInfo()
            {
                Data = "77777",
                Angle = 0,
                Height = 100,
                Width = 200,
                IsAddSign = false,
                TypeBarcode = EBarcodeFormats.EAN5
            };

            var actual = BarcodeEncoder.Encode(info);

            actual.Image.Save("test-ean5.bmp");
        }
    }
}
