using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Factories;

namespace Infrastructure.Providers.GCP;

public class GcpResourceFactory : ICloudResourceFactory
{
    public INetwork CreateNetwork(Dictionary<string, string> parameters)
        => new GcpNetwork(parameters);

    public IStorage CreateStorage(Dictionary<string, string> parameters)
        => new GcpStorage(parameters);

    public IVirtualMachine CreateVirtualMachine()
        => new GcpVirtualMachine();
}
