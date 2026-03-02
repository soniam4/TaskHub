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

            using (var scope1 = host.Services.CreateScope())
            {
                var sp = scope1.ServiceProvider;
                Console.WriteLine("=== Scope 1 ===");
                sp.ResolveTwice<ISingleton1>("Scope1");
                sp.ResolveTwice<ISingleton2>("Scope1");
                sp.ResolveTwice<IScoped1>("Scope1");
                sp.ResolveTwice<IScoped2>("Scope1");
                sp.ResolveTwice<ITransient1>("Scope1");
                sp.ResolveTwice<ITransient2>("Scope1");
            }

            using (var scope2 = host.Services.CreateScope())
            {
                var sp = scope2.ServiceProvider;
                Console.WriteLine("\n=== Scope 2 ===");
                sp.ResolveTwice<ISingleton1>("Scope2");
                sp.ResolveTwice<ISingleton2>("Scope2");
                sp.ResolveTwice<IScoped1>("Scope2");
                sp.ResolveTwice<IScoped2>("Scope2");
                sp.ResolveTwice<ITransient1>("Scope2");
                sp.ResolveTwice<ITransient2>("Scope2");
            }

            Console.WriteLine("\n=== После завершения scope (scoped должны быть уничтожены) ===");

            host.Run();
    }
}