using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Providers.OnPremise;

public class OnPremNetwork : INetwork
{
    public string Id { get; private set; } = string.Empty;
    private readonly string _physicalInterface;
    private readonly string _vlanId;
    private readonly string _firewallPolicy;

    public OnPremNetwork(Dictionary<string, string> parameters)
    {
        _physicalInterface = parameters.GetValueOrDefault("physicalInterface", "eth0");
        _vlanId = parameters.GetValueOrDefault("vlanId", "100");
        _firewallPolicy = parameters.GetValueOrDefault("firewallPolicy", "default-policy");
    }

    public void CreateNetwork()
    {
        Id = Guid.NewGuid().ToString();
        Console.WriteLine($"[OnPremise] Network creada en interfaz {_physicalInterface}, VLAN: {_vlanId}, Firewall: {_firewallPolicy}");
    }
}
