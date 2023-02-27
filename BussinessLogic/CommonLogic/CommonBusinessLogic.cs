using Data.DTO;

namespace BussinessLogic
{
    //common for all possible countries
    public class CommonBusinessLogic
    {
        public virtual void FetchGoodDetails(string endpoint, CommonObjectDTO commonObject)
        {
            //the same field, different endpoint
            commonObject.GoodsDetails = new List<GoodsDetailsDTO>() { 
                new GoodsDetailsDTO()
                {
                    DiscountValue = 2,
                    Qty = 3,
                    UnitPrice = 3
                } 
            };
        }

        public virtual void FetchUserDetails(string endpoint, CommonObjectDTO commonObject)
        {
            //the same field, different endpoint
            Console.WriteLine("Base common implementation");
        }

        public virtual void CalculateTax(CommonObjectDTO commonObject)
        {

        }
    }
}
