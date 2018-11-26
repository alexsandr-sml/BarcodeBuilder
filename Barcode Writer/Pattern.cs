namespace Barcodes
{
	using Barcodes.Common.Enums;
	using System;
    using System.Text.RegularExpressions;

    

	/// <summary>
	/// An individual module or pattern in a barcode
	/// </summary>
	public class Pattern
	{
		private EElements[] _State;

		public EElements[] Elements => _State;

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

		public Pattern(EElements[] pattern) : this()
		{
			_State = pattern;

			foreach (EElements item in _State)
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
			_State = new EElements[parts.Length];
			
			for (int i = 0; i < parts.Length; i++)
			{
				switch (parts[i])
				{
					case "ww":
						AddBar(EElements.WideWhite, i);
						break;
					case "wb":
						AddBar(EElements.WideBlack, i);
						break;
					case "0":
					case "nw":
						AddBar(EElements.NarrowWhite, i);
						break;
					case "1":
					case "nb":
						AddBar(EElements.NarrowBlack, i);
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
			_State = new EElements[value.Length];

			for (int i = 0; i < value.Length; i++)
			{
				switch (value[i])
				{
					case '0':
						AddBar(EElements.NarrowWhite, i);
						break;
					case '1':
						AddBar(EElements.NarrowBlack, i);
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
			_State = new EElements[(pattern.Length * 2)];

			for (int i = 0; i < pattern.Length; i++)
			{
				switch (pattern[i])
				{
					case 't':
						AddBar(EElements.Tracker, i * 2);
						break;
					case 'a':
						AddBar(EElements.Ascender, i * 2);
						break;
					case 'd':
						AddBar(EElements.Descender, i * 2);
						break;
					case 'f':
						AddBar(EElements.NarrowBlack, i * 2);
						break;
				}

				AddBar(EElements.WideWhite, (i * 2) + 1);

			}
		}

		/// <summary>
		/// Add a bar to this pattern
		/// </summary>
		/// <param name="bar">bar to add</param>
		/// <param name="index">index to add bar at</param>
		private void AddBar(EElements bar, int index)
		{
			_State[index] = bar;

			switch (bar)
			{
				case EElements.WideBlack:
					WideCount++;
					BlackCount++;
					break;
				case EElements.WideWhite:
					WideCount++;
					WhiteCount++;
					break;
				case EElements.NarrowWhite:
					NarrowCount++;
					WhiteCount++;
					break;
				case EElements.Tracker:
				case EElements.Ascender:
				case EElements.Descender:
				case EElements.NarrowBlack:
					NarrowCount++;
					BlackCount++;
					break;
			}
		}
	}
}
