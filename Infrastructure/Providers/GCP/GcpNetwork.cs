using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.GCP;

public class GcpNetwork : INetwork
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _networkName;
    private readonly string _subnetworkName;
    private readonly string _firewallTag;

    public GcpNetwork(Dictionary<string, string> parameters)
    {
        _networkName = parameters.GetValueOrDefault("networkName", "default-net");
        _subnetworkName = parameters.GetValueOrDefault("subnetworkName", "default-subnet");
        _firewallTag = parameters.GetValueOrDefault("firewallTag", "default-fw");
    }

    public void CreateNetwork()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[GCP] Network creada con Network: {_networkName}, Subnetwork: {_subnetworkName}, FirewallTag: {_firewallTag}");
    }
}
