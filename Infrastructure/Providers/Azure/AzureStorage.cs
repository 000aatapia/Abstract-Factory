using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.Azure;

public class AzureStorage : IStorage
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _diskSku;
    private readonly int _sizeGB;
    private readonly bool _managedDisk;

    public AzureStorage(Dictionary<string, string> parameters)
    {
        _diskSku = parameters.GetValueOrDefault("diskSku", "Standard_LRS");
        _sizeGB = int.Parse(parameters.GetValueOrDefault("sizeGB", "50"));
        _managedDisk = bool.Parse(parameters.GetValueOrDefault("managedDisk", "true"));
    }

    public void CreateStorage()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[Azure] Storage creado con SKU: {_diskSku}, {_sizeGB} GB, Managed: {_managedDisk}");
    }
}
