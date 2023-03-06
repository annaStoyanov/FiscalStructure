using Contracts;
using Data.DTO;

namespace Common
{
	public class DefaultAdaptor : IAdaptor
	{
		public string CountryCode { get; set; } = string.Empty;

		public string Template { get; set; } = string.Empty;

		public virtual async Task<RevenueAuthorityResponse> FiscalizeDocumentAsync(string requestBody)
		{
			// Always have RA URL
			// Most commonly used method for communication is HTTP Post with application/json

			// string response = HttpClient.Post(EndPoint, body = forRAWithLove);

			return new RevenueAuthorityResponse()
			{
				Message = "asd",
				Success = true,
				ResponseCode = "0001", 
				// Message = response.Content,
				// Success = responce.Success,
				// ResponseCode = responce.SuccessCode
			};
		}
	}
}