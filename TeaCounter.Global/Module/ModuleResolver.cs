using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TeaCounter.Global.Module
{
    public static class ModuleResolver
    {
        private static IUnityContainer _ioc;
        public static void Init(IUnityContainer ioc)
        {
            _ioc = ioc;
        }

        public static IUnityContainer Container
        {
            get
            {
                if (_ioc == null)
                    throw new ArgumentNullException(nameof(_ioc), "Initialize ModuleResolver in first place.");
                return _ioc;
            }
        }

        public static T Resolve<T>()
        {
            return _ioc.Resolve<T>();
        }

        public static T Resolve<T>(string name)
        {
            return _ioc.Resolve<T>(name);
        }

        public static Lazy<T> LazyResolve<T>()
        {
            return _ioc.Resolve<Lazy<T>>();
        }
    }
}
