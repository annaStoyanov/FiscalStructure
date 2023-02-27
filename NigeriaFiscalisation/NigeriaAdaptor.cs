using MAHCommonBusinessLogic;
using MAHContracts;

namespace NigeriaAdaptor
{
    public class NigeriaFiscalizer : IAdaptor
    {
        //cound this be string
        public string CountryCode => "NGR";

        public void FiscaliseDocument(string message)
        {
            Console.WriteLine($"Call from NigeriaAdaptor");
        }
    }
}