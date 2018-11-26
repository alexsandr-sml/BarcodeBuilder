using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barcodes.Common.Interfaces
{
	/// <summary>
	/// Defines the initialiser for the Reed Solomon functions
	/// </summary>
	public interface IInitialiser
	{
		int G { get; }
		int GetECCCount(int dataCount, int level);
	}
}
