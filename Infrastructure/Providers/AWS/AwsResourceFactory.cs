using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Factories;

namespace Infrastructure.Providers.AWS;

public class AwsResourceFactory : ICloudResourceFactory
{
    public INetwork CreateNetwork(Dictionary<string, string> parameters)
        => new AwsNetwork(parameters);

    public IStorage CreateStorage(Dictionary<string, string> parameters)
        => new AwsStorage(parameters);

    public IVirtualMachine CreateVirtualMachine()
        => new AwsVirtualMachine();
}