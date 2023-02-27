using Data.DTO;
using MAHContracts;

namespace Orchestrator
{
    public interface IMessageProcessor
    {
        public void Process(InputObject message);
    }
}
