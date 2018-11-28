using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace nht.barcodes._1D
{
    public class Ean
    {
        public string BuldBitMask(string data, int cs, string patternCode)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(patternCode))
            {
                throw new Exception($"{nameof(BuldBitMask)}. One or more required parameters is null");
            }

            var _sb = new StringBuilder();
            ///добавляем признак начала
            _sb.Append(EAN_Constants.LRGP);

			var remainder = data.Length % 2;
			for (var i = 0; i < data.Length / 2 + remainder; i++)
            {
                _sb.Append(patternCode[i] == 'L' ? EAN_Constants.LCode[Convert.ToInt32(data.Substring(i + 1, 1))] :
                                                   EAN_Constants.GCode[Convert.ToInt32(data.Substring(i + 1, 1))]);
			}

            ///adding separator
            _sb.Append(EAN_Constants.CGP);

            for (var i = data.Length / 2 + 1; i < data.Length; i++)
            {
                _sb.Append(EAN_Constants.RCode[Convert.ToInt32(data.Substring(i, 1))]);
			}

            ////adding checksum
            _sb.Append(EAN_Constants.RCode[cs]);

            ///добавляем признак конца
            _sb.Append(EAN_Constants.LRGP);

            return _sb.ToString();
        }

        public int GetChecksum(string data)
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
            if (cs == 10)
                cs = 0;

            return cs % 10;
        }
    }
}
