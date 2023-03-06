using Contracts;
using System.Reflection;

namespace MessageProcessor
{
    public static class PluginsHelper
    {
        public static List<Assembly> LoadPluginAssemblies()
        {
            DirectoryInfo pluginsDirectoryInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            List<FileInfo> externalProjectDlls = new List<FileInfo>();

            foreach (var dicrectoryInfo in pluginsDirectoryInfo.GetDirectories())
            {
                FileInfo[] files = dicrectoryInfo.GetFiles("*.dll");
                externalProjectDlls.AddRange(files);
            }
            
            var assemblies = new List<Assembly>();
            foreach (var fileInfo in externalProjectDlls)
            {
                assemblies.Add(Assembly.LoadFile(fileInfo.FullName));
            }

            return assemblies;
        }

        public static IAdaptor? GetAdaptor(Assembly assembly)
        {
            var availableTypes = assembly.GetTypes();
            var adaptor = availableTypes
                .SingleOrDefault((x) => x.GetInterface(nameof(IAdaptor)) != null);         
            
            return adaptor != null 
                ? Activator.CreateInstance(adaptor) as IAdaptor
                : null;
        }

        public static IBusinessLogic? GetLogic(Assembly assembly)
        {
            var availableTypes = assembly.GetTypes();
            var logic = availableTypes
                .SingleOrDefault((x) => x.GetInterface(nameof(IBusinessLogic)) != null);

            return logic != null 
                ? Activator.CreateInstance(logic) as IBusinessLogic
                : null;
        }
    }
}
