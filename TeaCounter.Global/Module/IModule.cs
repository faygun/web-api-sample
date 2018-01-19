using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaCounter.Global.Module
{
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
