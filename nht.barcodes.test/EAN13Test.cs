using nht.barcodes._1D;
using NUnit.Framework;

namespace Tests
{
	public class EAN13Test
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void EAN13Generate()
		{
			var expected = "460123456789";
			//var expected_bit = "10101011110100111001100100100110100001001110101010100111010100001000100100100011101001000010101";
			var ean13 = new EAN13();
			var actual = ean13.Encode(expected);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected + "3", actual.Barcode);
		}
	}
}