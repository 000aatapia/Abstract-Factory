using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Factories;

namespace Infrastructure.Providers.OnPremise;

public class OnPremResourceFactory : ICloudResourceFactory
{
    public INetwork CreateNetwork(Dictionary<string, string> parameters)
        => new OnPremNetwork(parameters);

    public IStorage CreateStorage(Dictionary<string, string> parameters)
        => new OnPremStorage(parameters);

    public IVirtualMachine CreateVirtualMachine()
        => new OnPremVirtualMachine();
}
