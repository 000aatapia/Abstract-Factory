using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.AWS;

public class AwsStorage : IStorage
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _volumeType;
    private readonly int _sizeGB;
    private readonly bool _encrypted;

    public AwsStorage(Dictionary<string, string> parameters)
    {
        _volumeType = parameters.GetValueOrDefault("volumeType", "gp2");
        _sizeGB = int.Parse(parameters.GetValueOrDefault("sizeGB", "50"));
        _encrypted = bool.Parse(parameters.GetValueOrDefault("encrypted", "false"));
    }

    public void CreateStorage()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[AWS] Storage creado con tipo {_volumeType}, {_sizeGB} GB, Encriptado: {_encrypted}");
    }
}