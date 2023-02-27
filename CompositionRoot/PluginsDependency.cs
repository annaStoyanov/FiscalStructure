using MAHContracts;
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
                var adaptor = PluginsHelper.getAdaptor(assembly);
                if (adaptor != null)
                {
                    services.AddScoped<IAdaptor>((sp) =>
                    {
                        //is active atribute
                        return adaptor;
                    });
                }
               
                var logic = PluginsHelper.getLogic(assembly);
                if (logic != null)
                {
                    services.AddScoped<ISpecificLogic>((sp) =>
                    {
                        return logic;
                    });
                }
            }

            return services;
        }
    }
}
