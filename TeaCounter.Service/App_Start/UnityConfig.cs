using System;
using TeaCounter.Global.Module;
using Unity;
using Unity.Interception.ContainerIntegration;

namespace TeaCounter.Service
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer().AddNewExtension<Interception>();
            RegisterTypes(container);
            return container;
        });


        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            ModuleLoader.LoadContainer(container, "TeaCounter.*.dll");
        }
    }
}