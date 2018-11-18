﻿
namespace Barcodes2
{
    /// <summary>
    /// Stores coefficients used by the Reed Solomon function
    /// </summary>
    internal class CoefficientsCollection : System.Collections.ObjectModel.KeyedCollection<int, byte[]>
    {
        protected override int GetKeyForItem(byte[] item)
        {
            return item.Length;
        }
    }
}
