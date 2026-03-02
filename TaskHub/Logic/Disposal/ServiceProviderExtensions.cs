using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Disposal
{
    public static class ServiceProviderExtensions
    {
        public static void ResolveTwice<T>(this IServiceProvider provider, string scopeName)
            where T : IHasInstanceId
        {
            var first = provider.GetRequiredService<T>();
            var second = provider.GetRequiredService<T>();

            Console.WriteLine($"[{scopeName}] {typeof(T).Name}: first={first.InstanceId}, second={second.InstanceId}, equal={first.InstanceId == second.InstanceId}");
        }
    }
}
