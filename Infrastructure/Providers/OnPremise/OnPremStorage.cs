using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.OnPremise;

public class OnPremStorage : IStorage
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _storagePool;
    private readonly int _sizeGB;
    private readonly string _raidLevel;

    public OnPremStorage(Dictionary<string, string> parameters)
    {
        _storagePool = parameters.GetValueOrDefault("storagePool", "pool1");
        _sizeGB = int.Parse(parameters.GetValueOrDefault("sizeGB", "100"));
        _raidLevel = parameters.GetValueOrDefault("raidLevel", "RAID5");
    }

    public void CreateStorage()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[OnPremise] Storage creado en pool {_storagePool}, {_sizeGB} GB, RAID: {_raidLevel}");
    }
}
