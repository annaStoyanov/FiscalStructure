using Common;
using Contracts;
using Data.DTO;

namespace Orchestrator
{
	public class MessageProcessor : IMessageProcessor
	{
		private readonly IAdaptor _adaptor;
		private readonly IBusinessLogic _businessLogic;
		private readonly CommonBusinessLogic _commonBusinessLogic;

		public MessageProcessor(IAdaptor adaptor,
			IBusinessLogic businessLogic,
			CommonBusinessLogic commonBusinessLogic)
		{
			this._adaptor = adaptor;
			this._businessLogic = businessLogic;
			this._commonBusinessLogic = commonBusinessLogic;
		}

		public async Task ProcessAsync(InputObject message)
		{
			var generalObject = new GeneralObject();

			//TODO: validation of the common object 
            await this._commonBusinessLogic.PopulateFieldsAsync(generalObject);
            await this._businessLogic.PopulateFieldsAsync(generalObject);
            
            string template = await this._commonBusinessLogic.FetchTemplateAsync();

			/* template
			* {
			*      "name": "{{CustomerDetails.Name}}",
			*      "file": "{{GeneralObject.Image}}"
			* }
			*/

			// TODO: Move this into plugins
			string requestBody = await this.PopulateTemplatePlaceholders(generalObject, template); 
			
			/* requestBody
            * {
            *      "name": "SomeNameHere",
            *      "file": "somePictureHere.jpg"
            * }
            */

			var raResponse = await this._adaptor.FiscalizeDocumentAsync(requestBody);

			//TODO: Save RaResponse to db
		}

		private Task<string> PopulateTemplatePlaceholders(GeneralObject generalObject, string template)
		{
			throw new NotImplementedException();
		}
	}
}