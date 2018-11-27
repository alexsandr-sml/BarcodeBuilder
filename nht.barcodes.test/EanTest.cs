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
        public void EanGetChecksum(string data, int checksum)
        {
            var ean = new Ean();
            var actual = ean.GetChecksum(data);

            //var f = CheckDigit(data);

            Assert.IsTrue(actual == checksum);
        }

        private int CheckDigit(string data)
        {
            //calculate the checksum digit
            int even = 0;
            int odd = 0;

            //odd
            for (int i = 0; i <= 6; i += 2)
            {
                odd += int.Parse(data.Substring(i, 1)) * 3;
            }//for

            //even
            for (int i = 1; i <= 5; i += 2)
            {
                even += int.Parse(data.Substring(i, 1));
            }//for

            int total = even + odd;
            int checksum = total % 10;
            checksum = 10 - checksum;
            if (checksum == 10)
                checksum = 0;

            //add the checksum to the end of the 
            return checksum;
        }
    }
}