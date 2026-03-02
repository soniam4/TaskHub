using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Disposal
{
    public interface IHasInstanceId
    {
        Guid InstanceId { get; }
    }
}
