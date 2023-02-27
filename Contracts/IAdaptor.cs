using Data.DTO;

namespace Contracts
{
    public interface IAdaptor
    {
        public string CountryCode { get; set; }

        public Task<RevenueAuthorityResponse> FiscaliseDocumentAsync(GeneralObject generalObject, string template);
    }
}
