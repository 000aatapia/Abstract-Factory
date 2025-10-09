using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Factories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services;

public class ProvisioningService : IProvisioningService
{
    private readonly Dictionary<string, ICloudResourceFactory> _factories;

    public ProvisioningService(Dictionary<string, ICloudResourceFactory> factories)
    {
        _factories = factories ?? throw new ArgumentNullException(nameof(factories));
    }

    public async Task<ProvisioningResponseDto> ProvisionResourcesAsync(ProvisioningRequestDto request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (!_factories.TryGetValue(request.Provider.ToLower(), out var factory))
        {
            return new ProvisioningResponseDto
            {
                Provider = request.Provider,
                Success = false,
                Message = $"Proveedor '{request.Provider}' no soportado."
            };
        }

        try
        {
            INetwork network = factory.CreateNetwork(request.NetworkParameters);
            IStorage storage = factory.CreateStorage(request.StorageParameters);
            IVirtualMachine vm = factory.CreateVirtualMachine();

            network.CreateNetwork();
            storage.CreateStorage();
            vm.Provision(network, storage);

            var result = ProvisioningResult.Ok(
                Guid.NewGuid().ToString(),
                "Recursos aprovisionados correctamente."
            );

            return ProvisioningResponseDto.FromResult(request.Provider, result);
        }
        catch (Exception ex)
        {
            var result = ProvisioningResult.Fail($"Error en aprovisionamiento: {ex.Message}");
            return ProvisioningResponseDto.FromResult(request.Provider, result);
        }
    }
}