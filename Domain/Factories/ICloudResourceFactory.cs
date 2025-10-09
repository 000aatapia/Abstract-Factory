using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Factories
{
    public interface ICloudResourceFactory
    {
        INetwork CreateNetwork(Dictionary<string, string> parameters);
        IStorage CreateStorage(Dictionary<string, string> parameters);
        IVirtualMachine CreateVirtualMachine();
    }
}
