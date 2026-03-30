using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Disposal
{
    // Интерфейс
    public interface IHasInstanceId
    {
        Guid InstanceId { get; }
    }

    // Базовый класс 
    public abstract class DisposedService : IHasInstanceId, IDisposable
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        private readonly string _serviceName;

        protected DisposedService(string serviceName)
        {
            _serviceName = serviceName;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [CREATE] +++ {serviceName} создан, ID: {InstanceId}");
        }

        public void Dispose()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [DISPOSE] --- {_serviceName} уничтожен, ID: {InstanceId}");
        }
    }

    // 2 Singleton 
    public interface ISingleton1 : IHasInstanceId { }
    public class Singleton1 : DisposedService, ISingleton1
    {
        public Singleton1() : base("Singleton1") { }
    }

    public interface ISingleton2 : IHasInstanceId { }
    public class Singleton2 : DisposedService, ISingleton2
    {
        public Singleton2() : base("Singleton2") { }
    }

    // 2 Scoped
    public interface IScoped1 : IHasInstanceId { }
    public class Scoped1 : DisposedService, IScoped1
    {
        public Scoped1() : base("Scoped1") { }
    }

    public interface IScoped2 : IHasInstanceId { }
    public class Scoped2 : DisposedService, IScoped2
    {
        public Scoped2() : base("Scoped2") { }
    }

    // 2 Transient
    public interface ITransient1 : IHasInstanceId { }
    public class Transient1 : DisposedService, ITransient1
    {
        public Transient1() : base("Transient1") { }
    }

    public interface ITransient2 : IHasInstanceId { }
    public class Transient2 : DisposedService, ITransient2
    {
        public Transient2() : base("Transient2") { }
    }
}
