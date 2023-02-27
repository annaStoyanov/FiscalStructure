//using Business.Clients;
//using Data.DTO;

//namespace BussinessLogic
//{
//    public class ZimbabveSpecificLogic : ILogicBase
//    {
//        private readonly AfricaTwoCommonLogic africaTwoBussinessLogic;

//        public ZimbabveSpecificLogic(AfricaTwoCommonLogic africaTwoBussinessLogic)
//        {
//            this.africaTwoBussinessLogic = africaTwoBussinessLogic;
//        }

//        public void Execute(CommonObjectDTO commonObject)
//        {
//            africaTwoBussinessLogic.FetchGoodDetails(commonObject);
//            africaTwoBussinessLogic.FetchUserDetails(commonObject);
            
//            CalculateContrySpecific(commonObject);
//        }

//        private void CalculateContrySpecific(CommonObjectDTO commonObject)
//        {
//            //direct calculation or move to mediator in more then one country need the same field
//        }
//    }
//}
