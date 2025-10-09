using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.GCP;

public class GcpVirtualMachine : IVirtualMachine
{
    public string Id { get; private set; } = string.Empty;

    public void Provision(INetwork network, IStorage storage)
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[GCP] VM creada con NetworkID: {network.Id}, StorageID: {storage.Id}");
    }
}
