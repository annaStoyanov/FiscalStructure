using Contracts;
using MessageProcessor;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceRegister
{
    public static class PluginsDependency
    {
        public static IServiceCollection AddPluginServices(this IServiceCollection services)
        {
            var assemblies = PluginsHelper.LoadPluginAssemblies();
            foreach (var assembly in assemblies)
            {
                var businessLogic = PluginsHelper.GetLogic(assembly);
                if (businessLogic != null)
                {
                    services.AddScoped<IBusinessLogic>((sp) => businessLogic);
                }

                var adaptor = PluginsHelper.GetAdaptor(assembly);
                if (adaptor != null)
                {
                    services.AddScoped<IAdaptor>((sp) => adaptor);
                }
            }

            return services;
        }
    }
}
