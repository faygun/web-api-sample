using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Registration;

namespace TeaCounter.Global.Module
{
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterType<TFrom, TTo>(params object[] parameters) where TTo : TFrom;
        void RegisterType(Type t, params InjectionMember[] injectionMembers);
        void RegisterType<T>(params InjectionMember[] injectionMembers);
        void RegisterTypeWithInterceptor<TFrom, TTo>(params InjectionMember[] parameters) where TTo : TFrom;

        void AddSingleton<TFrom, TTo>() where TTo : TFrom;
        void AddSingleton<TFrom, TTo>(params object[] parameters) where TTo : TFrom;
        void AddSingleton(Type t, params InjectionMember[] injectionMembers);
        void AddSingleton<T>(params InjectionMember[] injectionMembers);
        void AddSingleton<T>(string name, params InjectionMember[] injectionMembers);
        void AddSingletonWithInterceptor<TFrom, TTo>(params InjectionMember[] parameters) where TTo : TFrom;
    }
}
