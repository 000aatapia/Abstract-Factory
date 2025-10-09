using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Factories;

namespace Infrastructure.Providers.Azure;

public class AzureResourceFactory : ICloudResourceFactory
{
    public INetwork CreateNetwork(Dictionary<string, string> parameters)
        => new AzureNetwork(parameters);

    public IStorage CreateStorage(Dictionary<string, string> parameters)
        => new AzureStorage(parameters);

    public IVirtualMachine CreateVirtualMachine()
        => new AzureVirtualMachine();
}
