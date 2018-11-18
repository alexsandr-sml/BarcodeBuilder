using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode.Net.Barcodes.Common
{
    public class BarcodeSize
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public float Width { get; set; } = 1000;

        /// <summary>
        /// Высота
        /// </summary>
        public float Height { get; set; } = 500;

        /// <summary>
        /// Отступ слева
        /// </summary>
        public float Left { get; set; } = 5;

        /// <summary>
        /// Отступ сверху
        /// </summary>
        public float Top { get; set; } = 5;

        /// <summary>
        /// Отступ справа
        /// </summary>
        public float Right { get; set; } = 5;

        /// <summary>
        /// Отступ снизу
        /// </summary>
        public float Bottom { get; set; } = 5;
    }
}
