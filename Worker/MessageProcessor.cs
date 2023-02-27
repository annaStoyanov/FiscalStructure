using Common;
using Contracts;
using Data.DTO;

namespace Orchestrator
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IAdaptor _adaptor;
        private readonly ICountrySpecificLogic _countrySpecificBusinessLogic;
        private readonly CommonBusinessLogic _commonBusinessLogic;

        public MessageProcessor(IAdaptor adaptor,
            ICountrySpecificLogic countrySpecificLogic,
            CommonBusinessLogic businessLogic)
        {
            this._adaptor = adaptor;
            this._countrySpecificBusinessLogic = countrySpecificLogic;
            this._commonBusinessLogic = businessLogic;
        }

        public async Task ProcessAsync(InputObject message)
        {
            var generalObject = new GeneralObject();
            
            await this._commonBusinessLogic.ExecuteAsync(generalObject);
            await this._countrySpecificBusinessLogic.UpdateCountrySpecificPropertiesAsync(generalObject);

            string template = await this._commonBusinessLogic.FetchTemplateAsync();
            var raResponse = await this._adaptor.FiscaliseDocumentAsync(generalObject, template);

            //TODO: Save RaResponse to db
        }
    }
}
