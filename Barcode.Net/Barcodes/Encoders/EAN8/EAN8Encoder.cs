namespace Barcode.Net.Barcodes.Encoders.EAN8
{
    using Common;
    using Interfaces;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;

    public class EAN8Encoder : IEncoder
    {
        private const string _encoderName = "EAN8";

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

        public bool IsDrawText { get; set; } = false;

        private string _barcode = string.Empty;

        public EAN8Encoder(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                throw new Exception("ШК не задан");

            if (barcode.Length < 7 || barcode.Length > 8)
                throw new Exception($"Неверная длина ШК {_barcode.Length}");

            if (barcode.Length == 7)
                _barcode = $"{barcode}{CalculateChecksumDigit(barcode)}";
            else
                _barcode = barcode;
        }

        public int CalculateChecksumDigit(string barcodetext)
        {
            int iSum = 0;
            int iDigit = 0;

            for (int i = 0; i < barcodetext.Length; i++)
            {
                iDigit = Convert.ToInt32(barcodetext.Substring(i, 1));
                iSum += (i % 2 == 0) ? iDigit * 3 : iDigit * 1;
            }

            return (10 - (iSum % 10)) % 10;
        }

        private string EAN8CodeInputText(string text)
        {
            var result = new StringBuilder(EAN_CODES.LeftRightGuardBars);
            for (int i = 0; i < text.Length; i++)
            {
                if (i == text.Length / 2)
                    result.Append(EAN_CODES.CenterGuardBars); //center guard bars

                result.Append(i < text.Length / 2 ? EAN_CODES.LCodes[Convert.ToInt32($"{text[i]}")] : EAN_CODES.RCodes[Convert.ToInt32($"{text[i]}")]);
            }
            result.Append(EAN_CODES.LeftRightGuardBars);

            return result.ToString();
        }

        private void DrawEan8Barcode(Graphics g)
        {
            var width = Size.Width - Size.Left - Size.Right;
            var height = Size.Height - Size.Top - Size.Bottom;

            GraphicsState gs = g.Save();

            var _binBarcode = EAN8CodeInputText(_barcode);
            var dx = width / _binBarcode.Length;

            var _offset = IsDrawText ? height * 0.2f : 0;
            var _fontSize = height * 0.19f;

            using (Pen pen = new Pen(Color.Black, dx))
            {
                var x = Size.Left + dx/2;
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
                    var fTextSize = g.MeasureString(_barcode.Substring(0, _barcode.Length / 2), font);
                    var dxTextOffset = fTextSize.Width / 2;
                    var dyTextOffset = fTextSize.Height * 0.75f;

                    var _left = _barcode.Substring(0, _barcode.Length / 2);
                    var _right = _barcode.Substring(_barcode.Length / 2);

                    g.DrawString(_left, font, Brushes.Black, new PointF(Size.Left + dx * _binBarcode.Length / 4 - dxTextOffset, Size.Height - Size.Bottom - dyTextOffset));
                    g.DrawString(_right, font, Brushes.Black, new PointF(Size.Left + dx * 3 * _binBarcode.Length / 4 - dxTextOffset, Size.Height - Size.Bottom - dyTextOffset));
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
                DrawEan8Barcode(g);
                return bmp;
            }
        }
    }
}
