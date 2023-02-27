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
                    services.AddScoped<ICountrySpecificLogic>((sp) =>
                    {
                        //is active atribute
                        return businessLogic;
                    });
                }

                var adaptor = PluginsHelper.GetAdaptor(assembly);
                if (adaptor != null)
                {
                    services.AddScoped<IAdaptor>((sp) =>
                    {
                        //is active atribute
                        return adaptor;
                    });
                }
            }

            return services;
        }
    }
}
