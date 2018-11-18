namespace Barcode.Net.Barcodes.Encoders.Interfaces
{
    using Common;
    using System.Drawing;

    public interface IEncoder
    {
        string Name { get; }

        BarcodeSize Size { get; set; }

        bool IsDrawText { get; set; }

        Bitmap CreateBarcode();
    }
}
