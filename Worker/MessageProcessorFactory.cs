using Common;
using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Orchestrator
{
	public class MessageProcessorFactory : IMessageProcessorFactory
	{
		private const string Endpoint = "RegionEndpoints";
		private readonly IServiceProvider services;

		public MessageProcessorFactory(IServiceProvider services)
		{
			this.services = services;
		}

		public IMessageProcessor CreateInstance(string countryCode)
		{
			var configuration = services.GetService<IConfiguration>();
			var businessLogic = services.GetServices<IBusinessLogic>()
				.SingleOrDefault(x => x.CountryCode == countryCode || x.CountryCode == string.Empty);
            
			if (string.IsNullOrEmpty(businessLogic!.CountryCode))
            {
                businessLogic.CountryCode = countryCode;
            }

            var commonBusinessLogicService = services.GetService<CommonBusinessLogic>();
			commonBusinessLogicService!.CountryCode = countryCode;
			commonBusinessLogicService!.Endpoint = configuration!
				.GetSection(Endpoint)
				.GetSection(countryCode)
				.Value;

			var adaptorService = this.services.GetServices<IAdaptor>()!
				.Where(x => x.CountryCode == countryCode || x.CountryCode == string.Empty)
				.MaxBy(x => x.CountryCode);

			if (string.IsNullOrEmpty(adaptorService!.CountryCode))
			{
				adaptorService.CountryCode = countryCode;
			}

			// Note that in this example, WorkerService can also have other dependencies
			// ActivatorUtilities.CreateInstance will automagically
			// resolve that dependency, and any others not explicitly provided, from
			// the specified IServiceProvider

			return ActivatorUtilities.CreateInstance<MessageProcessor>(services,
				new object[] { adaptorService, commonBusinessLogicService, businessLogic });
		}
	}
}