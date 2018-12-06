using nht.barcodes.Common;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace nht.barcodes._1D
{
    public class Ean
    {
        public virtual string BuldBitMask(string barcode, string patternCode)
        {
            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(patternCode))
            {
                throw new Exception($"{nameof(BuldBitMask)}. One or more required parameters is null");
            }

            var barcodeInt = barcode.Select(x => (int)char.GetNumericValue(x)).ToArray();

            var _sb = new StringBuilder();
            ///добавляем признак начала
            _sb.Append(EanConstants.LRGP);

            for (var i = 0; i < barcode.Length / 2; i++)
            {
                _sb.Append(patternCode[i] == 'L' ? EanConstants.LCode[barcodeInt[i]] :
                                                   EanConstants.GCode[barcodeInt[i]]);
            }

            ///adding separator
            _sb.Append(EanConstants.CGP);

            for (var i = barcode.Length / 2; i < barcode.Length; i++)
            {
                _sb.Append(EanConstants.RCode[Convert.ToInt32(barcode.Substring(i, 1))]);
            }

            ///добавляем признак конца
            _sb.Append(EanConstants.LRGP);

            return _sb.ToString();
        }

        public virtual int GetChecksum(string data)
        {
            var allDigits = data.Select(x => int.Parse(x.ToString(CultureInfo.InvariantCulture)))
                                .Reverse()
                                .ToArray();

            int odd = 0;
            int even = 0;
            for (int i = 0; i < allDigits.Length; i++)
            {
                if (i % 2 == 0)
                    odd += allDigits[i];
                else
                    even += allDigits[i];
            }

            int cs = 10 - ((even + odd * 3) % 10);

            return cs == 10 ? 0 : cs % 10;
        }

        public virtual Image BarcodeDraw(string barcodeBin, string barcodeText, BarcodeInfo info)
        {
            var image = new Bitmap(info.Width, info.Height);

            using (var graph = Graphics.FromImage(image))
            {
                graph.Clear(Color.White);

                using (var pen = new Pen(Brushes.Black, 2))
                {
                    var dx = (double)info.Width / barcodeBin.Length;
                    for (var i = 0; i < barcodeBin.Length; i++)
                    {
                        if (barcodeBin[i] == '1')
                        {
                            graph.FillRectangle(Brushes.Black, (float)(i * dx), 0, (float)dx, info.Height);
                        }
                    }

                    return image;
                }
            }
        }
    }
}
