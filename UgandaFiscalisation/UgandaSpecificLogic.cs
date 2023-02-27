using Common;
using Data.DTO;

namespace UgandaFiscalisation
{
    public class UgandaSpecificLogic : CommonBusinessLogic, IBaseLogic
    {
        public string CountryCode => "UGD";
        public void Execute(CommonObjectDTO commonObject)
        {
            base.FetchGoodDetails(commonObject);
            base.FetchUserDetails(commonObject);
            base.CalculateTax(commonObject);

            FetchCountrySpecificExtraDetail(commonObject);
        }
        private void FetchCountrySpecificExtraDetail(CommonObjectDTO commonObject)
        {
            //direct http call or use mediator here as well
        }
    }
}
