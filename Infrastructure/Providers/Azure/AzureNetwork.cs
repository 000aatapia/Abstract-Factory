using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.Azure;

public class AzureNetwork : INetwork
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _virtualNetwork;
    private readonly string _subnetName;
    private readonly string _networkSecurityGroup;

    public AzureNetwork(Dictionary<string, string> parameters)
    {
        _virtualNetwork = parameters.GetValueOrDefault("virtualNetwork", "vnet-default");
        _subnetName = parameters.GetValueOrDefault("subnetName", "subnet-default");
        _networkSecurityGroup = parameters.GetValueOrDefault("networkSecurityGroup", "nsg-default");
    }

    public void CreateNetwork()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[Azure] Network creada con VNet: {_virtualNetwork}, Subnet: {_subnetName}, NSG: {_networkSecurityGroup}");
    }
}
