using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.AWS;

public class AwsStorage : IStorage
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public void CreateStorage()
    {
        Console.WriteLine("[AWS] Creando volumen EBS.....");
    }
}