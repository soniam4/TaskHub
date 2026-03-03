using LoggingLibrary;
using Logic.Disposal;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        //  Демонстрация
        using (var scope1 = host.Services.CreateScope())
        {
            var sp = scope1.ServiceProvider;
            Console.WriteLine(">>> SCOPE  1 <<<");

            sp.CompareInstances<ISingleton1>("Scope1");
            sp.CompareInstances<ISingleton2>("Scope1");
            sp.CompareInstances<IScoped1>("Scope1");
            sp.CompareInstances<IScoped2>("Scope1");
            sp.CompareInstances<ITransient1>("Scope1");
            sp.CompareInstances<ITransient2>("Scope1");
        }

        Console.WriteLine("\n Между scope 1 и scope 2 ");
        Console.WriteLine("Scoped и Transient должны пересоздаться\n");

        using (var scope2 = host.Services.CreateScope())
        {
            var sp = scope2.ServiceProvider;
            Console.WriteLine(">>> SCOPE  2 <<<");

            sp.CompareInstances<ISingleton1>("Scope2");
            sp.CompareInstances<ISingleton2>("Scope2");
            sp.CompareInstances<IScoped1>("Scope2");
            sp.CompareInstances<IScoped2>("Scope2");
            sp.CompareInstances<ITransient1>("Scope2");
            sp.CompareInstances<ITransient2>("Scope2");
        }

        Console.WriteLine("Scoped сервисы должны быть уничтожены");

        host.Run();
    }
}