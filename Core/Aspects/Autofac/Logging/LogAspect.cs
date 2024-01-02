using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception //Aspect
    {
        protected override void OnBefore(IInvocation invocation)
        {
            Console.WriteLine($"Before invocation of method: {invocation.Method.Name}");
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine($"After invocation of method: {invocation.Method.Name}");
        }
    }
}
