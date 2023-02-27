using MAHContracts;
using System.Reflection;

namespace MessageProcessor
{
    public static class PluginsHelper
    {
        public static List<Assembly> LoadPluginAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");

            var assemblies = new List<Assembly>();

            foreach (var file in files)
            {
                assemblies.Add(Assembly.LoadFile(file.FullName));
            }

            return assemblies;
        }

        public static IAdaptor? getAdaptor(Assembly assembly)
        {
            var availableTypes = assembly.GetTypes();
            var adaptor = availableTypes.SingleOrDefault((x) => x.GetInterface("IAdaptor") != null);          
            return adaptor != null ? Activator.CreateInstance(adaptor) as IAdaptor:  null;
        }

        public static ISpecificLogic? getLogic(Assembly assembly)
        {
            var availableTypes = assembly.GetTypes();
            var logic = availableTypes.SingleOrDefault((x) => x.GetInterface("ISpecificLogic") != null);
            return logic != null ? Activator.CreateInstance(logic) as ISpecificLogic: null;
        }
    }
}
