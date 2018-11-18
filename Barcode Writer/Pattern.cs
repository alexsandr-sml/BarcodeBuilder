﻿namespace Barcodes
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Elements of a pattern
    /// </summary>
    public enum Elements
	{
		WideBlack,
		WideWhite,
		NarrowBlack,
		NarrowWhite,
		Tracker,
		Ascender,
		Descender
	}

	/// <summary>
	/// An individual module or pattern in a barcode
	/// </summary>
	public class Pattern
	{
		private Elements[] _State;

		public Elements[] Elements
        {
            get { return _State; }
		}

		/// <summary>
		/// Gets or sets the count of wide bars in the module
		/// </summary>
		internal int WideCount { get; set; }

		/// <summary>
		/// Gets or sets the count of narrow bars in the module
		/// </summary>
		internal int NarrowCount { get; set; }

		/// <summary>
		/// Gets or sets the count of black bars in the module
		/// </summary>
		internal int BlackCount { get; set;	}

		/// <summary>
		/// Gets or sets the count of white bars in the module
		/// </summary>
		internal int WhiteCount	{ get; set;	}

		public Pattern(Elements[] pattern) : this()
		{
			_State = pattern;

			foreach (Elements item in _State)
			{
				if ((int)item > 1)
					NarrowCount++;
				else
					WideCount++;
				if ((int)item % 2 == 0)
					BlackCount++;
				else
					WhiteCount++;
			}
		}

		private Pattern()
		{
		}

		/// <summary>
		/// Parse a textual pattern description into a module
		/// (0 - white, 1 - black)
		/// (ww - wide white, wb - wide black, nw - narrow white, nb - narrow black)
		/// (t - tracker, a - ascender, d - descender, f - full height)
		/// </summary>
		/// <param name="pattern">string to encode</param>
		/// <returns>pattern object</returns>
		public static Pattern Parse(string pattern)
		{
			Pattern result = new Pattern();

			if (Regex.IsMatch(pattern, "^[01]+$"))
				result.ParseBinary(pattern);
			else if (Regex.IsMatch(pattern, "^((0|1|[wn][wb]) ?)+$"))
				result.ParseFull(pattern);
			else if (Regex.IsMatch(pattern, "^[tadf]+$"))
				result.ParsePost(pattern);

			return result;
		}

		/// <summary>
		/// Parse the pattern using a space seperated description
		/// </summary>
		/// <param name="pattern">pattern to encode</param>
		private void ParseFull(string pattern)
		{
			string[] parts = pattern.Split(' ');
			_State = new Elements[parts.Length];
			
			for (int i = 0; i < parts.Length; i++)
			{
				switch (parts[i])
				{
					case "ww":
						AddBar(Barcodes.Elements.WideWhite, i);
						break;
					case "wb":
						AddBar(Barcodes.Elements.WideBlack, i);
						break;
					case "0":
					case "nw":
						AddBar(Barcodes.Elements.NarrowWhite, i);
						break;
					case "1":
					case "nb":
						AddBar(Barcodes.Elements.NarrowBlack, i);
						break;
					default:
						throw new ApplicationException("Unknown pattern element.");
				}
			}

		}

		/// <summary>
		/// Parse using a binary pattern
		/// </summary>
		/// <param name="pattern">pattern to encode</param>
		private void ParseBinary(string value)
		{
			_State = new Elements[value.Length];

			for (int i = 0; i < value.Length; i++)
			{
				switch (value[i])
				{
					case '0':
						AddBar(Barcodes.Elements.NarrowWhite, i);
						break;
					case '1':
						AddBar(Barcodes.Elements.NarrowBlack, i);
						break;
				}
			}

		}

		/// <summary>
		/// Parse using 4-state encodings
		/// </summary>
		/// <param name="pattern">pattern to encode</param>
		private void ParsePost(string pattern)
		{
			_State = new Elements[(pattern.Length * 2)];

			for (int i = 0; i < pattern.Length; i++)
			{
				switch (pattern[i])
				{
					case 't':
						AddBar(Barcodes.Elements.Tracker, i * 2);
						break;
					case 'a':
						AddBar(Barcodes.Elements.Ascender, i * 2);
						break;
					case 'd':
						AddBar(Barcodes.Elements.Descender, i * 2);
						break;
					case 'f':
						AddBar(Barcodes.Elements.NarrowBlack, i * 2);
						break;
				}

				AddBar(Barcodes.Elements.WideWhite, (i * 2) + 1);

			}
		}

		/// <summary>
		/// Add a bar to this pattern
		/// </summary>
		/// <param name="bar">bar to add</param>
		/// <param name="index">index to add bar at</param>
		private void AddBar(Elements bar, int index)
		{
			_State[index] = bar;

			switch (bar)
			{
				case Barcodes.Elements.WideBlack:
					WideCount++;
					BlackCount++;
					break;
				case Barcodes.Elements.WideWhite:
					WideCount++;
					WhiteCount++;
					break;
				case Barcodes.Elements.NarrowWhite:
					NarrowCount++;
					WhiteCount++;
					break;
				case Barcodes.Elements.Tracker:
				case Barcodes.Elements.Ascender:
				case Barcodes.Elements.Descender:
				case Barcodes.Elements.NarrowBlack:
					NarrowCount++;
					BlackCount++;
					break;
			}
		}
	}
}
