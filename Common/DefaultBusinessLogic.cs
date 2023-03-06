using Contracts;
using Data.DTO;

namespace Common
{
    public class DefaultBusinessLogic : IBusinessLogic
    {
        public string CountryCode { get; set; } = string.Empty;

        public Task PopulateFieldsAsync(GeneralObject generalObejct)
        {
            throw new NotImplementedException();
        }
    }
}
