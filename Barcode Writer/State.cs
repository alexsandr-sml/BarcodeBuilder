﻿namespace Barcodes
{
    using System.Drawing;

    /// <summary>
	/// Drawing state used to pass between methods
	/// </summary>
	public class State
	{
        public State(BarcodeSettings settings, int left, int top)
        {
            Left = left;
            Top = top;
            Settings = settings;
        }

        /// <summary>
        /// Gets or sets the current left position in pixels
        /// </summary>
        public int Left	{ get; set; }

		/// <summary>
		/// Gets or sets the current top position in pixels
		/// </summary>
		public int Top { get; set; }

		/// <summary>
		/// Gets the current canvas
		/// </summary>
		public Graphics Canvas { get; set; }

		/// <summary>
		/// Gets the current barcode settings
		/// </summary>
		public BarcodeSettings Settings { get; private set;	}

		/// <summary>
		/// Gets or sets the module to be drawn
		/// </summary>
		public char ModuleValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public CodedValueCollection Codes { get; set; }
	}
}
