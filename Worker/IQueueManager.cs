using Data.DTO;

namespace Orchestrator
{
    public interface IQueueManager
    {
        public Task<int> GetCount();

        public Task<InputObject> Dequeue();
    }
}
