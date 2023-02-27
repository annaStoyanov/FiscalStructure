using CompositionRoot;
using Contracts;
using ServiceRegister;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddServices();
                    services.AddPluginServices();
                })
                .Build();

            host.Run();
        }
    }
}