namespace Orchestrator
{
    public interface IMessageProcessorFactory
    {
        public IMessageProcessor CreateInstance(string countryName);
    }
}
