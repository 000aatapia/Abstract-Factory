using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.AWS;

public class AwsVirtualMachine : IVirtualMachine
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public void Provision(INetwork network, IStorage storage)
    {
        Console.WriteLine($"[AWS] Aprovisionando EC2 con red {network.Id} y disco {storage.Id}...");
    }
}