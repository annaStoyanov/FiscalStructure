using Contracts;
using Data.DTO;

namespace Common
{
    public class CommonAdaptor : IAdaptor
    {
        public string CountryCode { get; set; } = string.Empty;

        public string Template { get; set; } = string.Empty;

        public virtual async Task<RevenueAuthorityResponse> FiscaliseDocumentAsync(GeneralObject generalObject, string template)
        {
            throw new NotImplementedException();
        }
    }
}
