using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Factories;

namespace Infrastructure.Providers.AWS;

public class AwsCloudFactory : ICloudFactory
{
    public CloudProvider Provider => CloudProvider.AWS;

    public INetwork CreateNetwork() => new AwsNetwork();

    public IStorage CreateStorage() => new AwsStorage();

    public IVirtualMachine CreateVirtualMachine() => new AwsVirtualMachine();
}
