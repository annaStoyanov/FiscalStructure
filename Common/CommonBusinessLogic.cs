using Data.DTO;
using Microsoft.Extensions.Configuration;

namespace Common
{
    public class CommonBusinessLogic
    {
        public string Endpoint { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public async virtual Task FetchGoodDetailsAsync(GeneralObject commonObject)
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

        public async virtual Task FetchUserDetailsAsync(GeneralObject commonObject)
        {
            //the same field, different endpoint
            //laod endpoint from configuraton
            Console.WriteLine("Base common implementation");
        }

        public async virtual Task CalculateTaxAsync(GeneralObject commonObject)
        {
            throw new NotImplementedException();
        }

        public async Task PopulateFieldsAsync(GeneralObject commonObject)
        {
            throw new NotImplementedException();
        }

        public async Task<string> FetchTemplateAsync()
        {
            throw new NotImplementedException();
        }
    }
}