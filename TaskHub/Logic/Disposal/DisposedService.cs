using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Disposal
{
    public abstract class DisposedService : IHasInstanceId, IDisposable
    {
        public Guid InstanceId { get; } = Guid.NewGuid();

        protected DisposedService(string serviceName)
        {
            Console.WriteLine($"[CREATE] {serviceName} - {InstanceId}");
        }

        public void Dispose()
        {
            Console.WriteLine($"[DISPOSE] {this.GetType().Name} - {InstanceId}");
        }
    }
}
