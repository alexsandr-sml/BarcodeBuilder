using System;

namespace Barcodes2.GS1
{
	public class GS1Value
	{
		public int ApplicationIdentifier { get; private set; }

		public string Value { get; private set;	}

		private GS1Value(int applicationIdentifier)
		{
			ApplicationIdentifier = applicationIdentifier;
		}

		private bool Validate(string value)
		{
			string pattern;

			switch (ApplicationIdentifier)
			{
				case GS1AIConstants.SSCC18:
				case GS1AIConstants.ComponentId:
				case GS1AIConstants.GSRN:
					pattern = "^\\d{18}$";
					break;
				case GS1AIConstants.GTIN:
				case GS1AIConstants.NumberofContainersContained:
					pattern = "^\\d{14}$";
					break;
				case GS1AIConstants.BatchNumbers:
				case GS1AIConstants.SerialNumber:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1AIConstants.ProductionDate:
				case GS1AIConstants.DueDate:
				case GS1AIConstants.PackagingDate:
				case GS1AIConstants.BestBeforeDate:
				case GS1AIConstants.ExpirationDate:
					pattern = "^\\d{2}(0[1-9]|1[0-2])([0-2]\\d|3[01])$";
					break;
				case GS1AIConstants.VariantNumber:
				case GS1AIConstants.CouponExtendedCode0:
					pattern = "^\\d{2}$";
					break;
				case GS1AIConstants.SecondaryDataField:
					pattern = "^[a-z0-9]{1,29}$";
					break;
				case GS1AIConstants.AdditionalItemIdentification:
				case GS1AIConstants.CustomerPartNumber:
				case GS1AIConstants.SecondSerialNumber:
				case GS1AIConstants.ReferenceToSourceEntity:
				case GS1AIConstants.CustomerPurchaseOrderNumber:
				case GS1AIConstants.GINC:
				case GS1AIConstants.RoutingCode:
				case GS1AIConstants.UNCutClassification:
				case GS1AIConstants.GIAI:
				case GS1AIConstants.IBAN:
				case GS1AIConstants.CouponCodeIDNorthAmerica:
				case GS1AIConstants.TradingPartners:
				case GS1AIConstants.InternalCompanyCodes1:
				case GS1AIConstants.InternalCompanyCodes2:
				case GS1AIConstants.InternalCompanyCodes3:
				case GS1AIConstants.InternalCompanyCodes4:
				case GS1AIConstants.InternalCompanyCodes5:
				case GS1AIConstants.InternalCompanyCoeds6:
				case GS1AIConstants.InternalCompanyCodes7:
				case GS1AIConstants.InternalCompanyCodes8:
				case GS1AIConstants.InternalCompanyCodes9:
					pattern = "^[a-z0-9]{1,30}$";
					break;
				case GS1AIConstants.MadeToOrderVariationNumber:
					pattern = "^\\d{1,6}";
					break;
				case GS1AIConstants.GDTI:
					pattern = "^\\d{14,30}$";
					break;
				case GS1AIConstants.GLNExtension:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1AIConstants.CountofItems:
				case GS1AIConstants.CountofTradeItems:
					pattern = "^\\d{1,8}$";
					break;
				case GS1AIConstants.ProductNetWeightKg:
				case GS1AIConstants.ProductLengthMeters:
				case GS1AIConstants.ProductWidthMeters:
				case GS1AIConstants.ProductDepthMeters:
				case GS1AIConstants.ProductAreaSquareMeters:
				case GS1AIConstants.NetVolumeLiters:
				case GS1AIConstants.NetVolumeCubicMeters:
				case GS1AIConstants.NetWeightPounds:
				case GS1AIConstants.ProductLengthInches:
				case GS1AIConstants.ProductLengthFeet:
				case GS1AIConstants.ProductLengthYards:
				case GS1AIConstants.ProductWidthInches:
				case GS1AIConstants.ProductWidthFeet:
				case GS1AIConstants.ProductWidthYards:
				case GS1AIConstants.ProductDepthInches:
				case GS1AIConstants.ProductDepthFeet:
				case GS1AIConstants.ProductDepthYards:
				case GS1AIConstants.LogiticWeightKg:
				case GS1AIConstants.ContainerLengthMeters:
				case GS1AIConstants.ContainerWidthMeters:
				case GS1AIConstants.ContainerDepthMeters:
				case GS1AIConstants.ContainerAreaSquareMeters:
				case GS1AIConstants.LogisticVolumeLiters:
				case GS1AIConstants.LogisticVolumeCubicMeters:
				case GS1AIConstants.KilogramsPerSquareMetre:
				case GS1AIConstants.LogisticWeightPounds:
				case GS1AIConstants.ContainerLengthInches:
				case GS1AIConstants.ContainerLengthFeet:
				case GS1AIConstants.ContainerLengthYards:
				case GS1AIConstants.ContainerWidthInches:
				case GS1AIConstants.ContainerWidthFeet:
				case GS1AIConstants.ContainerWidthYards:
				case GS1AIConstants.ContainerDepthInches:
				case GS1AIConstants.ContainerDepthFeet:
				case GS1AIConstants.ContainerDepthYards:
				case GS1AIConstants.ProductAreaSquareInches:
				case GS1AIConstants.ProductAreaSquareFeet:
				case GS1AIConstants.ProductAreaSquareYards:
				case GS1AIConstants.ContainerAreaSquareInches:
				case GS1AIConstants.ContainerAreaSquareFeet:
				case GS1AIConstants.ContainerAreaSuqareYards:
				case GS1AIConstants.NetWeightTroyOunces:
				case GS1AIConstants.NetWeightOunces:
				case GS1AIConstants.NetVolumeQuarts:
				case GS1AIConstants.NetVolumeGallons:
				case GS1AIConstants.LogisticVolumeQuarts:
				case GS1AIConstants.LogisticVolumeGallons:
				case GS1AIConstants.NetVolumeCubicInches:
				case GS1AIConstants.NetVolumeCubicFeet:
				case GS1AIConstants.NetVolumeCubicYards:
				case GS1AIConstants.LogisticGrossVolumeCubicInches:
				case GS1AIConstants.LogisticGrossVolumeCubicFeet:
				case GS1AIConstants.LogisticGrossVolumeCubicYards:
					pattern = "^\\d{7}$";
					break;
				case GS1AIConstants.PricePerUnit:
				case GS1AIConstants.CouponExtendedCode:
					pattern = "^\\d{6}$";
					break;
				case GS1AIConstants.AmountPayable:
				case GS1AIConstants.AmountPayableArea:
					pattern = "^\\d{1,15}$";
					break;
				case GS1AIConstants.AmountPayableISO:
				case GS1AIConstants.AmountPayableAreaISO:
					pattern = "^\\d{4,18}$";
					break;
				case GS1AIConstants.GSIN:
					pattern = "^\\d{17}$";
					break;
				case GS1AIConstants.ShipToLocationCode:
				case GS1AIConstants.BillToLocationCode:
				case GS1AIConstants.PurchaseFromLocationCode:
				case GS1AIConstants.ShipForLocationCode:
				case GS1AIConstants.PhysicalLocationId:
				case GS1AIConstants.InvoicingPartyLocationCode:
				case GS1AIConstants.NATOStockNumber:
					pattern = "^\\d{13}$";
					break;
				case GS1AIConstants.ShipToPostalCode:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1AIConstants.ShipToPostalCodeISO:
					pattern = "^\\d{3}[a-z0-9]{1,9}$";
					break;
				case GS1AIConstants.CountryofOrigin:
				case GS1AIConstants.CountryOfProcessing:
				case GS1AIConstants.CountryOfDisassembly:
				case GS1AIConstants.CountryCoveringProcessChain:
					pattern = "^\\d{3}$";
					break;
				case GS1AIConstants.CountryOfInitialProcessing:
					pattern = "^\\d{3,15}$";
					break;
				case GS1AIConstants.ExpirationDateTime:
					pattern = "^\\d{10}$";
					break;
				case GS1AIConstants.ActivePotency:
					pattern = "^\\d{1,4}$";
					break;
				case GS1AIConstants.RollProducts:
					pattern = "^\\d{14}$";
					break;
				case GS1AIConstants.CellularMobileID:
					pattern = "^[a-z0-9]{1,20}$";
					break;
				case GS1AIConstants.GRAI:
					pattern = "^\\d{14}[a-z0-9]{1,16}$";
					break;
				case GS1AIConstants.ProductionDateTime:
					pattern = "^\\d{8,12}$";
					break;
				case GS1AIConstants.PaymentSlipReference:
					pattern = "^[a-z0-9]{1,25}$";
					break;
				case GS1AIConstants.CouponExtendedCodeEndofOffer:
					pattern = "^\\d{10}$";
					break;
				default:
					throw new NotSupportedException("Unsupported AI code [" + ApplicationIdentifier.ToString() + "].");
			}

			if (System.Text.RegularExpressions.Regex.IsMatch(value, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
				return true;

			throw new ApplicationException("The value does not meet the specification for the Application Identifier.");
		}

		public static GS1Value Create(int applicationIdentifier, string value)
		{
			var g = new GS1Value(applicationIdentifier);
			if (!g.Validate(value))
				return null;

			g.Value = value;
			return g;
		}

		public static GS1Value Create(int applicationIdentifier, int value)
		{
			return Create(applicationIdentifier, value.ToString());
		}

		public static GS1Value Create(int applicationIdentifier, decimal value, int precision)
		{
			string tmp = (value * (decimal)Math.Pow(10, precision)).ToString();

			if (precision < 0 || precision > 6)
				throw new ArgumentOutOfRangeException("precision", "Decimal precision must be between 0 and 6.");

			return Create(applicationIdentifier, precision.ToString() + tmp);
		}

		public static GS1Value Create(int applicationIdentifier, DateTime value)
		{
			return Create(applicationIdentifier, value, false);
		}

		public static GS1Value Create(int applicationIdentifier, DateTime value, bool ignoreDay)
		{
			string tmp = (ignoreDay) ? value.ToString("yyMM00") : value.ToString("yyMMdd");
			return Create(applicationIdentifier, tmp);
		}
	}
}
