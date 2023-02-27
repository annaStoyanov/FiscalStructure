using Data.DTO;

namespace MAHCommonBusinessLogic
{

    //common for all possible countries
    public class CommonBusinessLogic
    {
        public virtual void FetchGoodDetails( CommonObjectDTO commonObject)
        {
            //the same field, different endpoint
            //laod endpoint from configuraton
            commonObject.GoodsDetails = new List<GoodsDetailsDTO>() {
                new GoodsDetailsDTO()
                {
                    DiscountValue = 2,
                    Qty = 3,
                    UnitPrice = 3
                }
            };
        }

        public virtual void FetchUserDetails( CommonObjectDTO commonObject)
        {
            //the same field, different endpoint
            //laod endpoint from configuraton
            Console.WriteLine("Base common implementation");
        }

        public virtual void CalculateTax(CommonObjectDTO commonObject)
        {

        }
    }
}