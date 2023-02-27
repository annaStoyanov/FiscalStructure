using MAHCommonBusinessLogic;
using MAHContracts;

namespace UgandaFiscalisation
{
    public class UgandaAdaptor: IAdaptor
    {
        public string CountryCode => "UGD";
        public void FiscaliseDocument(string message)
        {
        }
    }
}