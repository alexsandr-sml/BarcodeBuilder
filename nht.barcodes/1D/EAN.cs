using System;
using System.Collections.Generic;
using System.Text;

namespace nht.barcodes._1D
{
	public struct Code
	{
		public byte L;
		public byte R;
		public byte G;
	}

	public class EAN
	{
		Dictionary<int, Code> dsd = new Dictionary<int, Code>();
	}


}
