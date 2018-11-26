using nht.barcodes.Common.Enums;

namespace nht.barcodes.Common
{
    public class BarcodeInfo
    {
        public EBarcodeFormats TypeBarcode { get; set; }

        public string Data { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsAddSign { get; set; }

        public double Angle { get; set; }
    }
}
