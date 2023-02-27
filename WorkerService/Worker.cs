using Orchestrator;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _services;

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _services.CreateScope();
            var queueManager = scope.ServiceProvider.GetService<IQueueManager>();
            var msgProcessorFactory = scope.ServiceProvider.GetRequiredService<IMessageProcessorFactory>();

            while (!stoppingToken.IsCancellationRequested)
            {
                if (queueManager != null && await queueManager.GetCount() > 0)
                {
                    await Task.Run(async () =>
                    {
                        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                        try
                        {
                            var msg = await queueManager.Dequeue();
                            var msgProcessor = msgProcessorFactory.CreateInstance(msg.CountryCode.ToUpperInvariant());
                            await msgProcessor.ProcessAsync(msg);
                        }
                        catch (System.InvalidOperationException ex)
                        {
                            // todo handle not yet registered country adapters
                            // country is not registered probably
                            Console.WriteLine(ex.Message);
                        }
                       
                    }, stoppingToken);
                }
                else
                {
                    await Task.Delay(3000, stoppingToken);
                }
            }
        }
      
    }
}