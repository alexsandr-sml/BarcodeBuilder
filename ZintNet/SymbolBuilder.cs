using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ZintNet
{
    /// <summary>
    /// Build the symbols row data.
    /// </summary>
    internal static class SymbolBuilder
    {
        public static void ExpandSymbolRow(Collection<SymbolData> Symbol, StringBuilder rowPattern, float height)
        {
            List<byte> rowData = new List<byte>();
            bool latch = true;	    // Start with a bar.
            for (int i = 0; i < rowPattern.Length; i++)
            {
                int value = rowPattern[i] - '0';
                for (int j = 0; j < value; j++)
                {
                    if (latch)
                        rowData.Add(1);

                    else
                        rowData.Add(0);
                }

                latch = !latch;
            }

            SymbolData symbolData = new SymbolData(rowData.ToArray(), height);
            Symbol.Add(symbolData);
        }
    }
}
