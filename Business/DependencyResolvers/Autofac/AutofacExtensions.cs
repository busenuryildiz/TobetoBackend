using Autofac.Builder;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddSubClassesOfType(
            this ContainerBuilder builder,
            Type type,
            Func<ContainerBuilder, Type, IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>>? addWithLifeCycle = null
        )
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    builder.RegisterType(item).AsImplementedInterfaces().InstancePerLifetimeScope();
                }
                else
                {
                    addWithLifeCycle(builder, item);
                }
            }

            return builder;
        }
        public static ContainerBuilder RegisterAspects(this ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                })
                .SingleInstance();

            return builder;
        }
    }
}
