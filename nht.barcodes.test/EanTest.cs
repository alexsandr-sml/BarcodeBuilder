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

        [TestCase("460123456789", 3, "LGLLGG")]
        public void EanBuldMask(string data, int checkSumm, string pattern)
        {
            var expected_bit_mask = "10101011110100111001100100100110100001001110101010100111010100001000100100100011101001000010101";

            var ean = new Ean();
            var actual = ean.BuldBitMask(data, checkSumm, pattern);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected_bit_mask, actual);
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