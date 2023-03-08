using Common;
using Microsoft.Extensions.DependencyInjection;
using Orchestrator;

namespace CompositionRoot
{
    public static class CompositionRoot
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //add more service if needed
            services.AddSingleton<IQueueManager, QueueManager>();
            services.AddScoped<IMessageProcessorFactory, MessageProcessorFactory>();
            services.AddScoped<CommonBusinessLogic>();

            return services;
        }
    }
}