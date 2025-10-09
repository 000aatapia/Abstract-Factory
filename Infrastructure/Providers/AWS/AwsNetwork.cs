using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.AWS;

public class AwsNetwork : INetwork
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public void CreateNetwork()
    {
        Console.WriteLine("[AWS] Creando red VPC/Subnet/SecurityGroup...");
    }
}