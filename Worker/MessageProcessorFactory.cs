using MAHContracts;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Orchestrator
{
    public class MessageProcessorFactory : IMessageProcessorFactory
    {
        private readonly IServiceProvider services;

        public MessageProcessorFactory(IServiceProvider services)
        {
            this.services = services;
        }
        public IMessageProcessor CreateInstance(string countryCode)
        {
            // instantiate service that needs runtime parameter
            //todo throw error when service don't exists
            var adaptorService = services.GetServices<IAdaptor>()
                .Single(x=>x.CountryCode == countryCode);
            var businessLogic = services.GetServices<ISpecificLogic>()
                .Single(x=>x.CountryCode == countryCode);

            if (adaptorService == null || businessLogic == null)
            {
                throw new ArgumentNullException("Country base logic is not specified yet.");
            }

            // Note that in this example, WorkerService can also have other dependencies
            // ActivatorUtilities.CreateInstance will automagically
            // resolve that dependency, and any others not explicitly provided, from
            // the specified IServiceProvider

            return ActivatorUtilities.CreateInstance<MessageProcessor>(services,
                new object[] { adaptorService, businessLogic });
        }
    }
}
