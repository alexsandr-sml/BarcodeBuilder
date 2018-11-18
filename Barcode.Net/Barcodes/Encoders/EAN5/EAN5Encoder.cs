namespace Barcode.Net.Barcodes.Encoders.EAN5
{
    using Common;
    using Interfaces;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;

    public class EAN5Encoder : IEncoder
    {
        private const string _encoderName = "EAN5";

        public string Name
        {
            get
            {
                return _encoderName;
            }
        }

        public BarcodeSize Size { get; set; } = new BarcodeSize()
        {
            Width = 1000,
            Height = 500,
            Left = 5,
            Top = 5,
            Right = 5,
            Bottom = 5
        };

        public bool IsDrawText { get; set; } = true;

        private readonly string[] _symbolPattern = { "GGLLL", "GLGLL", "GLLGL", "GLLLG", "LGGLL", "LLGGL", "LLLGG", "LGLGL", "LGLLG", "LLGLG" };

        private string _barcode = string.Empty;

        public EAN5Encoder(string barcode)
        {
            _barcode = barcode;
        }

        public Bitmap CreateBarcode()
        {
            var bmp = new Bitmap((int)Size.Width, (int)Size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DrawEan8Barcode(g);
                return bmp;
            }
        }

        private void DrawEan8Barcode(Graphics g)
        {
            var width = Size.Width - Size.Left - Size.Right;
            var height = Size.Height - Size.Top - Size.Bottom;

            GraphicsState gs = g.Save();

            var _binBarcode = EAN5CodeInputText(_barcode);
            var dx = width / _binBarcode.Length;

            var _offset = IsDrawText ? height * 0.2f : 0;
            var _fontSize = height * 0.19f;

            using (Pen pen = new Pen(Color.Black, dx))
            {
                var x = Size.Left + dx / 2;
                for (var i = 0; i < _binBarcode.Length; i++)
                {
                    if (_binBarcode[i] == '1')
                    {
                        g.DrawLine(pen, new PointF(x, Size.Top), new PointF(x, Size.Top + height - _offset));
                    }

                    x += dx;
                }
            }

            if (IsDrawText)
            {
                using (var font = new Font("Times", _fontSize))
                {
                    var fTextSize = g.MeasureString(_barcode, font);
                    var dxTextOffset = fTextSize.Width / 2;
                    var dyTextOffset = fTextSize.Height * 0.75f;

                    g.DrawString(_barcode, font, Brushes.Black, new PointF(Size.Left + dx * _binBarcode.Length / 2 - dxTextOffset, Size.Height - Size.Bottom - dyTextOffset));
                }
            }

            // Restore the GraphicsState.
            g.Restore(gs);
        }

        private string EAN5CodeInputText(string text)
        {
            var _index = CalculateChecksumDigit(text);
            var _codePart = _symbolPattern[_index];

            var result = new StringBuilder();
            result.Append("01011");
            for (int i = 0; i < text.Length; i++)
            {
                result.Append(_codePart[i] == 'L' ? EAN_CODES.LCodes[Convert.ToInt32($"{text[i]}")] : EAN_CODES.GCodes[Convert.ToInt32($"{text[i]}")]);
                if (i != text.Length - 1)
                    result.Append("01");
            }

            return result.ToString();
        }

        public int CalculateChecksumDigit(string barcodetext)
        {
            int iSum = 0;
            int iDigit = 0;

            for (int i = 0; i < barcodetext.Length; i++)
            {
                iDigit = Convert.ToInt32(barcodetext.Substring(i, 1));
                iSum += (i % 2 == 0) ? iDigit * 3 : iDigit * 9;
            }

            return iSum % 10;
        }
    }
}
