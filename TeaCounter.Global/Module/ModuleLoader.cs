using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TeaCounter.Global.Module
{
    public static class ModuleLoader
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static void LoadContainer(IUnityContainer container, string pattern)
        {
            string path = AssemblyDirectory;
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();

            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);
                        IEnumerable<IModule> modules = exports.Select(export => export.Value as IModule).Where(m => m != null);
                        var registrar = new ModuleRegistrar(container);
                        foreach (IModule module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }
                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
