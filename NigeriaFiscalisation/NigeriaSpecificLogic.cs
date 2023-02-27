using Data.DTO;
using MAHCommonBusinessLogic;
using MAHContracts;

namespace NigeriaAdaptor
{
    public class NigeriaSpecificLogic :  CommonBusinessLogic, ISpecificLogic
    {
        public NigeriaSpecificLogic()
        {

        }

        public string CountryCode => "NGR";

        public void Execute(CommonObjectDTO commonObject)
        {
            base.FetchGoodDetails(commonObject);
            base.FetchUserDetails(commonObject);
            base.CalculateTax(commonObject);

            this.FetchCountrySpecificExtraDetail(commonObject);
            this.CalculateTax(commonObject);
        }

        private void CalculateTax(CommonObjectDTO commonObject)
        {
            commonObject.BasicInformation = new BasicInformationDTO();
            commonObject.BasicInformation.Tax = 5;
        }

        //this is country specific logic 
        private void FetchCountrySpecificExtraDetail(CommonObjectDTO commonObject)
        {
            //call api here as it is country specific logic
        }
    }
}
