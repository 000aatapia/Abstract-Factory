using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.AWS;

public class AwsNetwork : INetwork
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _vpcId;
    private readonly string _subnet;
    private readonly string _securityGroupId;

    public AwsNetwork(Dictionary<string, string> parameters)
    {
        _vpcId = parameters.GetValueOrDefault("vpcId", "default-vpc");
        _subnet = parameters.GetValueOrDefault("subnet", "default-subnet");
        _securityGroupId = parameters.GetValueOrDefault("securityGroupId", "sg-default");
    }

    public void CreateNetwork()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[AWS] Network creada con VPC: {_vpcId}, Subnet: {_subnet}, SG: {_securityGroupId}");
    }
}