﻿using System;

namespace Barcodes
{
	public class AddChecksumEventArgs : EventArgs
	{
		public string Text { get; set; }

		public CodedValueCollection Codes { get; private set; }

		public AddChecksumEventArgs(string text, CodedValueCollection codes)
		{
			Text = text;
			Codes = codes;
		}

		public AddChecksumEventArgs(State state)
		{
			Text = state.Text;
			Codes = state.Codes;
		}
	}
}
