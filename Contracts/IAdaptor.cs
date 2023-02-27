namespace MAHContracts
{
    public interface IAdaptor
    {
        public string CountryCode { get; }

        public void FiscaliseDocument(string message);
    }
}
