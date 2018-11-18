namespace Barcode.Net.Barcodes.Common
{
    public class Code128Element
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Encoding { get; set; }

        public ECode128Type CyrrentType { get; set; }

        public Code128Element()
        {

        }
    }
}
