using nht.barcodes.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace nht.barcodes._1D
{
    public class Ean5 : Ean
    {
        private Dictionary<int, string> patternForEan5 = new Dictionary<int, string>()
        {
            {0, "GGLLL" },
            {1, "GLGLL" },
            {2, "GLLGL" },
            {3, "GLLLG" },
            {4, "LGGLL" },
            {5, "LLGGL" },
            {6, "LLLGG" },
            {7, "LGLGL" },
            {8, "LGLLG" },
            {9, "LLGLG" }
        };

        public Ean5()
        {

        }

        public BarcodeResult Encode(BarcodeInfo info)
        {
            //check length of input
            if (info.Data.Length != 5)
                throw new Exception("EAN-5: Data length invalid. (Length must be 4 or 6)");

            ///Вычисляем контрольную сумму
            var cs = GetChecksum(info.Data);

            var barcodeWithCheckSumm = $"{info.Data}{cs}";

            ///Первая цифра кодируется выбором способа кодирования 
            var patternCode = patternForEan5[cs];

            var _bitMask = BuldBitMask(info.Data, patternCode);

            return new BarcodeResult()
            {
                Image = BarcodeDraw(_bitMask, barcodeWithCheckSumm, info),
                Barcode = barcodeWithCheckSumm
            };
        }

        public override int GetChecksum(string data)
        {
            var allDigits = data.Select(x => int.Parse(x.ToString(CultureInfo.InvariantCulture)))
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

            int cs = 10 - ((even * 3 + odd * 9) % 10);

            return cs == 10 ? 0 : cs % 10;
        }

        public override string BuldBitMask(string barcode, string patternCode)
        {
            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(patternCode))
            {
                throw new Exception($"{nameof(BuldBitMask)}. One or more required parameters is null");
            }

            var barcodeInt = barcode.Select(x => (int)char.GetNumericValue(x)).ToArray();

            var _sb = new StringBuilder();
            ///добавляем признак начала
            _sb.Append("01011");

            for (var i = 0; i < barcode.Length; i++)
            {
                _sb.Append(patternCode[i] == 'L' ? EanConstants.LCode[barcodeInt[i]] :
                                                   EanConstants.GCode[barcodeInt[i]]);

                ///добавляем разделитель
                _sb.Append(i < barcode.Length - 1 ? "01" : "");
            }

            return _sb.ToString();
        }
    }
}
