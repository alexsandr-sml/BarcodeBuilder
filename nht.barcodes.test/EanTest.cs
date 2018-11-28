using nht.barcodes._1D;
using NUnit.Framework;

namespace nht.barcodes.test
{
    public class EanTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("4601234567893", "LGLLGG", "101010111101001110011001001001101000010011101010101011100100111010100001000100100100011101001000010101")]
        [TestCase("77777775", "LLLLLL", "1010111011011101101110110111011010101000100100010010001001001110101")]
        public void EanBuldMask(string barcode, string pattern, string expected)
        {
            var ean = new Ean();
            var actual = ean.BuldBitMask(barcode, pattern);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("460123456789", 3)]
        [TestCase("978111814330", 8)]
        [TestCase("1234567", 0)]
		[TestCase("9031101", 7)]
		public void EanGetChecksum(string data, int checksum)
        {
            var ean = new Ean();
            var actual = ean.GetChecksum(data);

            Assert.IsTrue(actual == checksum);
        }
    }
}