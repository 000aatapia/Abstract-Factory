using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.GCP;

public class GcpStorage : IStorage
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _diskType;
    private readonly int _sizeGB;
    private readonly bool _autoDelete;

    public GcpStorage(Dictionary<string, string> parameters)
    {
        _diskType = parameters.GetValueOrDefault("diskType", "pd-standard");
        _sizeGB = int.Parse(parameters.GetValueOrDefault("sizeGB", "50"));
        _autoDelete = bool.Parse(parameters.GetValueOrDefault("autoDelete", "false"));
    }

    public void CreateStorage()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[GCP] Storage creado con tipo {_diskType}, {_sizeGB} GB, AutoDelete: {_autoDelete}");
    }
}
