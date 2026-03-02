using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Disposal
{
    public interface ISingleton1 : IHasInstanceId { }
    public class Singleton1 : DisposedService, ISingleton1
    {
        public Singleton1() : base(nameof(Singleton1)) { }
    }

    public interface ISingleton2 : IHasInstanceId { }
    public class Singleton2 : DisposedService, ISingleton2
    {
        public Singleton2() : base(nameof(Singleton2)) { }
    }

    public interface IScoped1 : IHasInstanceId { }
    public class Scoped1 : DisposedService, IScoped1
    {
        public Scoped1() : base(nameof(Scoped1)) { }
    }

    public interface IScoped2 : IHasInstanceId { }
    public class Scoped2 : DisposedService, IScoped2
    {
        public Scoped2() : base(nameof(Scoped2)) { }
    }

    public interface ITransient1 : IHasInstanceId { }
    public class Transient1 : DisposedService, ITransient1
    {
        public Transient1() : base(nameof(Transient1)) { }
    }

    public interface ITransient2 : IHasInstanceId { }
    public class Transient2 : DisposedService, ITransient2
    {
        public Transient2() : base(nameof(Transient2)) { }
    }
}
