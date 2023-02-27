using Data.DTO;

namespace Orchestrator
{
    public class QueueManager : IQueueManager
    {
        private Queue<InputObject> azureQueue { get; set; }
        public QueueManager()
        {
            azureQueue = new Queue<InputObject>();
            azureQueue.Enqueue(new InputObject() { Id = 1, CountryCode = "NGA" });
            azureQueue.Enqueue(new InputObject() { Id = 1, CountryCode = "UGD" });
            azureQueue.Enqueue(new InputObject() { Id = 1, CountryCode = "UGD" });
            azureQueue.Enqueue(new InputObject() { Id = 1, CountryCode = "ZBW" });
        }

        public Task<int> GetCount()
        {
            return Task.Run(() =>
            {
                return azureQueue.Count;
            }); 
        }

        public Task<InputObject> Dequeue()
        {
            return Task.Run(() =>
            {
                return azureQueue.Dequeue();
            });
        }
    }
}
