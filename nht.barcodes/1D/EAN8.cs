﻿using nht.barcodes.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace nht.barcodes._1D
{
	public class Ean8 : Ean
	{
		public Ean8()
		{

		}

		public BarcodeResult Encode(BarcodeInfo info)
		{
			//check length of input
			if (info.Data.Length < 7 || info.Data.Length > 9)
				throw new Exception("EAN-8: Data length invalid. (Length must be 7 or 9)");

			///Вычисляем контрольную сумму
			var cs = GetChecksum(info.Data);

			var barcodeWithCheckSumm = $"{info.Data}{cs}";

			///Первая цифра кодируется выбором способа кодирования 
			var patternCode = EAN_Constants.Pattern[0];

			var _bitMask = BuldBitMask(info.Data, cs, patternCode);

			return new BarcodeResult()
			{
				Image = BarcodeDraw(_bitMask, barcodeWithCheckSumm, info),
				Barcode = barcodeWithCheckSumm
			};
		}

		private Image BarcodeDraw(string barcodeBin, string barcodeText, BarcodeInfo info)
		{
			var image = new Bitmap(info.Width, info.Height);

			using (var graph = Graphics.FromImage(image))
			{
				graph.Clear(Color.White);

				using (var pen = new Pen(Brushes.Black, 2))
				{
					if (!info.IsAddSign)
					{
						var dx = (double)info.Width / barcodeBin.Length;
						var pointer = 0;
						for (var position = 0.0; position < info.Width; position += dx)
						{
							if (pointer < barcodeBin.Length && barcodeBin[pointer] == '1')
							{
								graph.FillRectangle(Brushes.Black, (float)position, 0, (float)dx, info.Height);
							}

							pointer++;
						}
					}
					else
					{
						using (var font = new Font("Times", 14f))
						{
							var dx = (double)info.Width / barcodeBin.Length;

							var pointer = 0;
							for (var position = 0.0; position < info.Width; position += dx)
							{
								if (pointer < barcodeBin.Length && barcodeBin[pointer] == '1')
								{
									graph.FillRectangle(Brushes.Black, (float)position, 5, (float)dx, info.Height - 15);
								}

								pointer++;
							}

							graph.FillRectangle(Brushes.White, (float)(dx * 3), info.Height - 20, (float)(dx * 28), 15);
							graph.FillRectangle(Brushes.White, (float)(dx * 3 + dx * 28) + (float)(dx * 4), info.Height - 20, (float)(dx * 28), 15);

							var sf = new StringFormat()
							{
								Alignment = StringAlignment.Center
							};

							//graph.DrawString(barcodeText.Substring(0, 1), font, Brushes.Black, 0, info.Height - 22);
							//graph.DrawString(barcodeText.Substring(1, 6), font, Brushes.Black, new RectangleF((float)(15 + dx * 3), info.Height - 22, (float)(dx * 42), 22), sf);
							//graph.DrawString(barcodeText.Substring(7, 6), font, Brushes.Black, new RectangleF((float)(15 + dx * 3 + dx * 4 + dx * 42), info.Height - 22, (float)(dx * 42), 22), sf);
						}
					}

					return image;
				}
			}
		}
	}
}
