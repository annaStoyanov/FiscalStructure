using Data.DTO;
using MAHContracts;

namespace Orchestrator
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IAdaptor _adaptor;
        private readonly ISpecificLogic _businessLogic;

        public MessageProcessor(IAdaptor adaptor,
            ISpecificLogic businessLogic)
        {
            this._adaptor = adaptor;
            this._businessLogic = businessLogic;
        }

        public void Process(InputObject message)
        {
            var commonObject = new CommonObjectDTO();
            this._businessLogic.Execute(commonObject);
            var mappedObjectAsString = "<xml></xml>";//todo 
            this._adaptor.FiscaliseDocument(mappedObjectAsString);
        }

    }
}
