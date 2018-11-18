namespace Barcode.Net.Barcodes.Encoders.EAN13
{
    using Common;
    using Interfaces;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;

    public class EAN13Encoder : IEncoder
    {
        private const string _encoderName = "EAN13";

        public string Name
        {
            get
            {
                return _encoderName;
            }
        }

        public BarcodeSize Size { get; set; } = new BarcodeSize()
        {
            Width = 1250,
            Height = 500,
            Left = 5,
            Top = 5,
            Right = 5,
            Bottom = 5
        };

        public bool IsDrawText { get; set; } = false;

        private readonly string[] _leftFirstSymbolPattern =  { "LLLLLL", "LLGLGG", "LLGGLG", "LLGGGL", "LGLLGG", "LGGLLG", "LGGGLL", "LGLGLG", "LGLGGL", "LGGLGL" };

        private COUNTRY_CODES CountryCode { get; set; } = COUNTRY_CODES.RUSSIAN_FEDERATION;

        private string ManufacturerCode { get; set; }

        private string ProductCode { get; set; }

        private EAN13Encoder()
        {
        }

        public EAN13Encoder(string mfgNumber, string productId)
        {
            ManufacturerCode = mfgNumber;
            ProductCode = productId;
        }

        public EAN13Encoder(COUNTRY_CODES countryCode, string mfgNumber, string productId)
        {
            CountryCode = countryCode;
            ManufacturerCode = mfgNumber;
            ProductCode = productId;
        }

        public int CalculateChecksumDigit(string barcodetext)
        {
            int iSum = 0;
            int iDigit = 0;

            for (int i = 0; i < barcodetext.Length; i++)
            {
                iDigit = Convert.ToInt32(barcodetext.Substring(i, 1));
                iSum += (i % 2 == 0) ? iDigit * 1 : iDigit * 3;
            }

            return (10 - (iSum % 10)) % 10;
        }

        private string EAN8CodeInputText(string text, int checksum)
        {     
            var _codeLeftPart = _leftFirstSymbolPattern[Convert.ToInt32($"{text[0]}")];
            var result = new StringBuilder();
            result.Append(EAN_CODES.LeftRightGuardBars);

            for (int i = 1; i < text.Length; i++)
            {
                if (i == text.Length / 2 + 1)
                    result.Append(EAN_CODES.CenterGuardBars); //center guard bars

                var _index = Convert.ToInt32($"{text[i]}");
                if (i < text.Length / 2 + 1)
                {          
                    result.Append(_codeLeftPart[i - 1] == 'L' ? EAN_CODES.LCodes[_index] : EAN_CODES.GCodes[_index]);
                }
                else
                {
                    result.Append(EAN_CODES.RCodes[_index]);
                }
            }
            result.Append(EAN_CODES.RCodes[checksum]);
            result.Append(EAN_CODES.LeftRightGuardBars);

            return result.ToString();
        }

        private void DrawEan13Barcode(Graphics g, Point pt)
        {
            var width = Size.Width - Size.Left - Size.Right;
            var _widthOffset = width * 0.07f;
            var height = Size.Height - Size.Top - Size.Bottom;

            GraphicsState gs = g.Save();

            string _barcode = $"{(int)CountryCode:D3}{ManufacturerCode}{ProductCode}";

            var _chsum = CalculateChecksumDigit(_barcode);
            var _binBarcode = EAN8CodeInputText(_barcode, _chsum);
            var dx = (width - _widthOffset) / _binBarcode.Length;

            var _offset = IsDrawText ? height * 0.2f : 0;
            var _fontSize = height * 0.19f;

            using (Pen pen = new Pen(Color.Black, dx))
            {
                var x = Size.Left + dx / 2 + _widthOffset;
                for (var i = 0; i < _binBarcode.Length; i++)
                {
                    if (_binBarcode[i] == '1')
                    {
                        if (i < 4 || i > _binBarcode.Length - 4)
                            g.DrawLine(pen, new PointF(x, Size.Top), new PointF(x, Size.Top + height));
                        else if (i > _binBarcode.Length / 2 - 2 && i < _binBarcode.Length / 2 + 2)
                            g.DrawLine(pen, new PointF(x, Size.Top), new PointF(x, Size.Top + height));
                        else
                            g.DrawLine(pen, new PointF(x, Size.Top), new PointF(x, Size.Top + height - _offset));
                    }

                    x += dx;
                }
            }

            if (IsDrawText)
            {
                using (var font = new Font("Times", _fontSize))
                {
                    var fTextSize = g.MeasureString(_barcode.Substring(0, (_barcode.Length - 1) / 2), font);
                    var dxTextOffset = fTextSize.Width * 0.55f;
                    var dyTextOffset = fTextSize.Height * 0.75f;

                    _barcode = _barcode + _chsum.ToString();

                    var _first = _barcode.Substring(0, 1);
                    var _left  = _barcode.Substring(1, (_barcode.Length - 1) / 2);
                    var _right = _barcode.Substring((_barcode.Length - 1) / 2 + 1);

                    g.DrawString(_first, font, Brushes.Black, new PointF(Size.Left, Size.Height - Size.Bottom - dyTextOffset));
                    g.DrawString(_left , font, Brushes.Black, new PointF(Size.Left + dx * 1 / 4 * _binBarcode.Length - dxTextOffset + _widthOffset, Size.Height - Size.Bottom - dyTextOffset));
                    g.DrawString(_right, font, Brushes.Black, new PointF(Size.Left + dx * 3 / 4 * _binBarcode.Length - dxTextOffset + _widthOffset, Size.Height - Size.Bottom - dyTextOffset));
                }
            }

            // Restore the GraphicsState.
            g.Restore(gs);
        }

        public Bitmap CreateBarcode()
        {
            var bmp = new Bitmap((int)Size.Width, (int)Size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DrawEan13Barcode(g, new Point(0, 0));
                return bmp;
            }
        }
    }
}
