using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Disposal
{
    public static class DisposalExtensions
    {
        public static void CompareInstances<T>(this IServiceProvider services, string scopeName)
            where T : IHasInstanceId
        {
            // Резолвим два раза
            var first = services.GetService<T>();
            var second = services.GetService<T>();

            // Сравниваем
            bool areSame = ReferenceEquals(first, second);
            string result = areSame ? "Одинаковые" : "Разные";

            // Выводим результат
            Console.WriteLine($"[{scopeName}] {typeof(T).Name}:");
            Console.WriteLine($"   first  = {first.InstanceId}");
            Console.WriteLine($"   second = {second.InstanceId}");
            Console.WriteLine($"   => {result}\n");
        }
    }
}
