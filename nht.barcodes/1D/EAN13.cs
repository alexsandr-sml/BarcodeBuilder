using nht.barcodes.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace nht.barcodes._1D
{
    public class EAN13
    {
        public EAN13()
        {

        }

        private char[] code = new char[13];

        public BarcodeResult Encode(string data)
        {
            //check length of input
            if (data.Length < 12 || data.Length > 13)
                throw new Exception("EEAN13-1: Data length invalid. (Length must be 12 or 13)");

            var _sb = new StringBuilder();
            ///добавляем признак начала
            _sb.Append(EAN_Constants.LRGP);
            ///Первая цифра кодируется выбором способа кодирования 
            var patternCode = EAN_Constants.Pattern[Convert.ToInt32(data.Substring(0, 1))];

            for (var i = 0; i < 6; i++)
            {
                _sb.Append(patternCode[i] == 'L' ? EAN_Constants.LCode[Convert.ToInt32(data.Substring(i + 1, 1))] :
                                                   EAN_Constants.GCode[Convert.ToInt32(data.Substring(i + 1, 1))]);
            }

            ///добавляем разделитель
            _sb.Append(EAN_Constants.CGP);

            for (var i = 7; i < 12; i++)
            {
                _sb.Append(EAN_Constants.RCode[Convert.ToInt32(data.Substring(i, 1))]);
            }

            var cs = CheckDigit(data);

            ////add checksum
            _sb.Append(EAN_Constants.RCode[cs]);

            ///добавляем признак конца
            _sb.Append(EAN_Constants.LRGP);

            return new BarcodeResult()
            {
                Image = BarcodeDraw(_sb.ToString(), 300, 100),
                Barcode = $"{data}{cs}"
            };
        }

        private Image BarcodeDraw(string barcode, int width, int height)
        {
            var image = new Bitmap(width, height);

            using (var graph = Graphics.FromImage(image))
            {
                graph.Clear(Color.White);

                using (Pen pen = new Pen(Brushes.Black, 2))
                {
                    var dx = (double)width / barcode.Length;

                    var pointer = 0;

                    for (var position = 0.0; position < width; position += dx)
                    {
                        if (pointer < barcode.Length && barcode[pointer] == '1')
                        {
                            graph.FillRectangle(Brushes.Black, (float)position, 0, (float)dx, 100);
                        }

                        pointer++;
                    }

                    return image;
                }
            }
        }

        private int CheckDigit(string data)
        {
            var _rawDataHolder = data.Substring(0, 12);

            int even = 0;
            int odd = 0;

            for (int i = 0; i < _rawDataHolder.Length; i++)
            {
                if (i % 2 == 0)
                    odd += int.Parse(_rawDataHolder.Substring(i, 1));
                else
                    even += int.Parse(_rawDataHolder.Substring(i, 1)) * 3;
            }

            int cs = 10 - ((even + odd) % 10);
            if (cs == 10)
                cs = 0;

            return Convert.ToInt32(cs.ToString().Substring(0, 1));
        }
    }
}
