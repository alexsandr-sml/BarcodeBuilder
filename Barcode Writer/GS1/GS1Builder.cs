using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Barcodes.GS1
{
	public class GS1Builder
	{
		private List<int> _Ais;
		private List<string> _Values;

		public char FNC1 { get; private set; }

		public ReadOnlyCollection<int> AICollection => new ReadOnlyCollection<int>(_Ais);

		public ReadOnlyCollection<string> Values => new ReadOnlyCollection<string>(_Values);

		public GS1Builder()
			: this(Code128Helper.FNC1)
		{ }

		public GS1Builder(char fnc1)
		{
			_Ais = new List<int>();
			_Values = new List<string>();
			FNC1 = fnc1;
		}

		public void Add(int ai, string value)
		{
			Validate(ai, value);

			_Ais.Add(ai);
			_Values.Add(value);
		}

		public void Add(int ai, int value)
		{
			Add(ai, value.ToString());
		}

		public void Add(int ai, decimal value, int precision)
		{
			string tmp = (value * (decimal)Math.Pow(10, precision)).ToString();
			Validate(ai, tmp);

			if (precision < 0 || precision > 6)
				throw new ArgumentOutOfRangeException("precision", "Decimal precision must be between 0 and 6.");

			Add(ai, precision.ToString() + tmp);
		}

		public void Add(int ai, DateTime value)
		{
			Add(ai, value, false);
		}

		public void Add(int ai, DateTime value, bool ignoreDay)
		{
			string tmp;
			if (ignoreDay)
				tmp = value.ToString("yyMM00");
			else
				tmp = value.ToString("yyMMdd");

			Add(ai, tmp);
		}

		public void RemoveAt(int index)
		{
			_Ais.RemoveAt(index);
			_Values.RemoveAt(index);
		}

		private bool Validate(int ai, string value)
		{
			string pattern;

			switch (ai)
			{
				case GS1_Constants.SSCC18:
				case GS1_Constants.ComponentId:
				case GS1_Constants.GSRN:
					pattern = "^\\d{18}$";
					break;
				case GS1_Constants.GTIN:
				case GS1_Constants.NumberofContainersContained:
					pattern = "^\\d{14}$";
					break;
				case GS1_Constants.BatchNumbers:
				case GS1_Constants.SerialNumber:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1_Constants.ProductionDate:
				case GS1_Constants.DueDate:
				case GS1_Constants.PackagingDate:
				case GS1_Constants.BestBeforeDate:
				case GS1_Constants.ExpirationDate:
					pattern = "^\\d{2}(0[1-9]|1[0-2])([0-2]\\d|3[01])$";
					break;
				case GS1_Constants.VariantNumber:
				case GS1_Constants.CouponExtendedCode0:
					pattern = "^\\d{2}$";
					break;
				case GS1_Constants.SecondaryDataField:
					pattern = "^[a-z0-9]{1,29}$";
					break;
				case GS1_Constants.AdditionalItemIdentification:
				case GS1_Constants.CustomerPartNumber:
				case GS1_Constants.SecondSerialNumber:
				case GS1_Constants.ReferenceToSourceEntity:
				case GS1_Constants.CustomerPurchaseOrderNumber:
				case GS1_Constants.GINC:
				case GS1_Constants.RoutingCode:
				case GS1_Constants.UNCutClassification:
				case GS1_Constants.GIAI:
				case GS1_Constants.IBAN:
				case GS1_Constants.CouponCodeIDNorthAmerica:
				case GS1_Constants.TradingPartners:
				case GS1_Constants.InternalCompanyCodes1:
				case GS1_Constants.InternalCompanyCodes2:
				case GS1_Constants.InternalCompanyCodes3:
				case GS1_Constants.InternalCompanyCodes4:
				case GS1_Constants.InternalCompanyCodes5:
				case GS1_Constants.InternalCompanyCoeds6:
				case GS1_Constants.InternalCompanyCodes7:
				case GS1_Constants.InternalCompanyCodes8:
				case GS1_Constants.InternalCompanyCodes9:
					pattern = "^[a-z0-9]{1,30}$";
					break;
				case GS1_Constants.MadeToOrderVariationNumber:
					pattern = "^\\d{1,6}";
					break;
				case GS1_Constants.GDTI:
					pattern = "^\\d{14,30}$";
					break;
				case GS1_Constants.GLNExtension:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1_Constants.CountofItems:
				case GS1_Constants.CountofTradeItems:
					pattern = "^\\d{1,8}$";
					break;
				case GS1_Constants.ProductNetWeightKg:
				case GS1_Constants.ProductLengthMeters:
				case GS1_Constants.ProductWidthMeters:
				case GS1_Constants.ProductDepthMeters:
				case GS1_Constants.ProductAreaSquareMeters:
				case GS1_Constants.NetVolumeLiters:
				case GS1_Constants.NetVolumeCubicMeters:
				case GS1_Constants.NetWeightPounds:
				case GS1_Constants.ProductLengthInches:
				case GS1_Constants.ProductLengthFeet:
				case GS1_Constants.ProductLengthYards:
				case GS1_Constants.ProductWidthInches:
				case GS1_Constants.ProductWidthFeet:
				case GS1_Constants.ProductWidthYards:
				case GS1_Constants.ProductDepthInches:
				case GS1_Constants.ProductDepthFeet:
				case GS1_Constants.ProductDepthYards:
				case GS1_Constants.LogiticWeightKg:
				case GS1_Constants.ContainerLengthMeters:
				case GS1_Constants.ContainerWidthMeters:
				case GS1_Constants.ContainerDepthMeters:
				case GS1_Constants.ContainerAreaSquareMeters:
				case GS1_Constants.LogisticVolumeLiters:
				case GS1_Constants.LogisticVolumeCubicMeters:
				case GS1_Constants.KilogramsPerSquareMetre:
				case GS1_Constants.LogisticWeightPounds:
				case GS1_Constants.ContainerLengthInches:
				case GS1_Constants.ContainerLengthFeet:
				case GS1_Constants.ContainerLengthYards:
				case GS1_Constants.ContainerWidthInches:
				case GS1_Constants.ContainerWidthFeet:
				case GS1_Constants.ContainerWidthYards:
				case GS1_Constants.ContainerDepthInches:
				case GS1_Constants.ContainerDepthFeet:
				case GS1_Constants.ContainerDepthYards:
				case GS1_Constants.ProductAreaSquareInches:
				case GS1_Constants.ProductAreaSquareFeet:
				case GS1_Constants.ProductAreaSquareYards:
				case GS1_Constants.ContainerAreaSquareInches:
				case GS1_Constants.ContainerAreaSquareFeet:
				case GS1_Constants.ContainerAreaSuqareYards:
				case GS1_Constants.NetWeightTroyOunces:
				case GS1_Constants.NetWeightOunces:
				case GS1_Constants.NetVolumeQuarts:
				case GS1_Constants.NetVolumeGallons:
				case GS1_Constants.LogisticVolumeQuarts:
				case GS1_Constants.LogisticVolumeGallons:
				case GS1_Constants.NetVolumeCubicInches:
				case GS1_Constants.NetVolumeCubicFeet:
				case GS1_Constants.NetVolumeCubicYards:
				case GS1_Constants.LogisticGrossVolumeCubicInches:
				case GS1_Constants.LogisticGrossVolumeCubicFeet:
				case GS1_Constants.LogisticGrossVolumeCubicYards:
					pattern = "^\\d{7}$";
					break;
				case GS1_Constants.PricePerUnit:
				case GS1_Constants.CouponExtendedCode:
					pattern = "^\\d{6}$";
					break;
				case GS1_Constants.AmountPayable:
				case GS1_Constants.AmountPayableArea:
					pattern = "^\\d{1,15}$";
					break;
				case GS1_Constants.AmountPayableISO:
				case GS1_Constants.AmountPayableAreaISO:
					pattern = "^\\d{4,18}$";
					break;
				case GS1_Constants.GSIN:
					pattern = "^\\d{17}$";
					break;
				case GS1_Constants.ShipToLocationCode:
				case GS1_Constants.BillToLocationCode:
				case GS1_Constants.PurchaseFromLocationCode:
				case GS1_Constants.ShipForLocationCode:
				case GS1_Constants.PhysicalLocationId:
				case GS1_Constants.InvoicingPartyLocationCode:
				case GS1_Constants.NATOStockNumber:
					pattern = "^\\d{13}$";
					break;
				case GS1_Constants.ShipToPostalCode:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1_Constants.ShipToPostalCodeISO:
					pattern = "^\\d{3}[a-z0-9]{1,9}$";
					break;
				case GS1_Constants.CountryofOrigin:
				case GS1_Constants.CountryOfProcessing:
				case GS1_Constants.CountryOfDisassembly:
				case GS1_Constants.CountryCoveringProcessChain:
					pattern = "^\\d{3}$";
					break;
				case GS1_Constants.CountryOfInitialProcessing:
					pattern = "^\\d{3,15}$";
					break;
				case GS1_Constants.ExpirationDateTime:
					pattern = "^\\d{10}$";
					break;
				case GS1_Constants.ActivePotency:
					pattern = "^\\d{1,4}$";
					break;
				case GS1_Constants.RollProducts:
					pattern = "^\\d{14}$";
					break;
				case GS1_Constants.CellularMobileID:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1_Constants.GRAI:
					pattern = "^\\d{14}[a-z0-9]{1,16}$";
					break;
				case GS1_Constants.ProductionDateTime:
					pattern = "^\\d{8,12}$";
					break;
				case GS1_Constants.PaymentSlipReference:
					pattern = "^[a-z0-9]{1,25}$";
					break;
				case GS1_Constants.CouponExtendedCodeEndofOffer:
					pattern = "^\\d{10}$";
					break;
				default:
					throw new NotSupportedException("Unsupported AI code [" + ai.ToString() + "].");
			}

			if (System.Text.RegularExpressions.Regex.IsMatch(value, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
				return true;

			throw new ApplicationException("The value does not meet the specification for the AI.");
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			for (int i = 0; i < _Ais.Count; i++)
			{
				sb.Append(FNC1);
				sb.Append(_Ais[i]);
				sb.Append(_Values[i]);
			}

			return sb.ToString();
		}

		public string ToString(char fnc1)
		{
			FNC1 = fnc1;
			return ToString();
		}

		public string ToDisplayString()
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < _Ais.Count; i++)
			{
				sb.AppendFormat("({0})", _Ais[i]);
				sb.Append(_Values[i]);
			}

			return sb.ToString();
		}
	}
}
