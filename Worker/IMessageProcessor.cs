using Data.DTO;
using Contracts;

namespace Orchestrator
{
    public interface IMessageProcessor
    {
        public Task ProcessAsync(InputObject message);
    }
}
