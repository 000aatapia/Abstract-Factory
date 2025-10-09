using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Factories
{
    public interface ICloudFactory
    {
        CloudProvider Provider { get; }
        INetwork CreateNetwork();
        IStorage CreateStorage();
        IVirtualMachine CreateVirtualMachine();
    }
}
