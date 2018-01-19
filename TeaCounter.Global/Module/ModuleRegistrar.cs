using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Registration;

namespace TeaCounter.Global.Module
{
    public class ModuleRegistrar : IModuleRegistrar
    {
        private readonly IUnityContainer _container;
        public ModuleRegistrar(IUnityContainer container)
        {
            _container = container; //Register interception behaviour if any
        }
        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }

        public void RegisterType<TFrom, TTo>(params object[] parameters) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new InjectionConstructor(parameters));
        }

        public void RegisterType<T>(params InjectionMember[] injectionMembers)
        {
            _container.RegisterType<T>(injectionMembers);
        }

        public void RegisterTypeWithInterceptor<TFrom, TTo>(params InjectionMember[] parameters) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(parameters);
        }

        public void AddSingleton<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }

        public void AddSingleton<TFrom, TTo>(params object[] parameters) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager(), new InjectionConstructor(parameters));
        }

        public void AddSingletonWithInterceptor<TFrom, TTo>(params InjectionMember[] parameters) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager(), parameters);
        }

        public void RegisterType(Type t, params InjectionMember[] injectionMembers)
        {
            _container.RegisterType(t, injectionMembers);
        }

        public void AddSingleton(Type t, params InjectionMember[] injectionMembers)
        {
            _container.RegisterType(t, new ContainerControlledLifetimeManager(), injectionMembers);
        }

        public void AddSingleton<T>(params InjectionMember[] injectionMembers)
        {
            _container.RegisterType<T>(new ContainerControlledLifetimeManager(), injectionMembers);
        }

        public void AddSingleton<T>(string name, params InjectionMember[] injectionMembers)
        {
            _container.RegisterType<T>(name, new ContainerControlledLifetimeManager(), injectionMembers);
        }
    }
}
