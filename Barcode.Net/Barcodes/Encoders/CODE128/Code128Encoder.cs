namespace Barcode.Net.Barcodes.Encoders.CODE128
{
    using Common;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;

    public class Code128Encoder : IEncoder
    {
        private const string _encoderName = "CODE128";

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

        private string _barcode = string.Empty;

        public Code128Encoder(string barcode)
        {
            _barcode = barcode;
        }

        public Bitmap CreateBarcode()
        {
            var bmp = new Bitmap((int)Size.Width, (int)Size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DrawCode128Barcode(g);
                return bmp;
            }
        }

        private void DrawCode128Barcode(Graphics g)
        {
            var width = Size.Width - Size.Left - Size.Right;
            var height = Size.Height - Size.Top - Size.Bottom;

            GraphicsState gs = g.Save();

            var _binBarcode = Code128CodeInputText(_barcode);
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

        private string Code128CodeInputText(string text)
        {
            var _list = new List<Code128Element>();

            _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["WhiteZone"]]); //добавляет белую защитную зону

            ECode128Type _currentType;
            var _remand = text.Length % 4;

            if (text.Length < 4)
            {
                _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["START_C"]]);
            }
            else
            {
                for (var i = 0; i < text.Length - _remand; i++)
                {
                    if (i == 0)
                    {
                        var _tmp = char.IsNumber(text[i]) && char.IsNumber(text[i + 1]) && char.IsNumber(text[i + 2]) && char.IsNumber(text[i + 3]);
                        if(_tmp)
                        {
                            _currentType = ECode128Type.C;
                            _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["START_C"]]);
                        }
                        else
                        {
                            if(char.IsControl(text[i]))
                            {
                                _currentType = ECode128Type.B;
                                _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["START_B"]]);
                            }
                            else
                            {
                                _currentType = ECode128Type.A;
                                _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["START_A"]]);
                            }
                        }

                        _list.Add(CODE128_CODES.Codes[CODE128_CODES.ACodes["START_A"]]);
                    }

                    var _elem = text[i];
                    if (char.IsNumber(_elem))
                    {

                    }

                    if (char.IsLetter(_elem))
                    {

                    }


                }
            }


            var _index = CalculateChecksumDigit(text);
            var _codePart = "";

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
            int iSum = barcodetext[0];
            for (int i = 0; i < barcodetext.Length; i++)
            {
                iSum += barcodetext[i] * i;
            }

            return iSum % 103;
        }
    }
}
