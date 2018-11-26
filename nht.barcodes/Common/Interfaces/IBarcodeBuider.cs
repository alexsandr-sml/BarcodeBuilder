namespace nht.barcodes.Common.Interfaces
{
	public interface IBarcodeBuider<TIn, TOut>
	{
		TOut Build(TIn value);
	}
}
