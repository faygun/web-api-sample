using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaCounter.Business.Interfaces;
using TeaCounter.Business.Services;
using TeaCounter.Global.Module;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace TeaCounter.Business
{
    [Export(typeof(IModule))]
    public class ModuleInit:IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.AddSingleton<IProductService, ProductService>();
        }
    }
}
