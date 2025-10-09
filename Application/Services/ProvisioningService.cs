using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Factories;


namespace Application.Services;

public class ProvisioningService : IProvisioningService
{
    private readonly IEnumerable<ICloudFactory> _factories;
    public ProvisioningService(IEnumerable<ICloudFactory> factories)
    {
        _factories = factories;
    }
    public async Task<ProvisioningResponseDto> ProvisionAsync(ProvisioningRequestDto request)
    {
        var response = new ProvisioningResponseDto();
        try
        {
            var factory = _factories.FirstOrDefault(f => f.Provider == request.Provider);
            if (factory == null)
                throw new InvalidOperationException($"No se encontró una fábrica para el proveedor {request.Provider}");

            var network = factory.CreateNetwork();
            var storage = factory.CreateStorage();
            var vm = factory.CreateVirtualMachine();

            network.CreateNetwork();
            storage.CreateStorage();
            vm.Provision(network, storage);

            response.VmId = vm.Id;
            response.NetworkId = network.Id;
            response.StorageId = storage.Id;
            response.Status = "Provisioned";
            response.Message = $"Recursos aprovisonados correctamente en {request.Provider}";

        }
        catch (Exception ex)
        {
            response.Status = "Failed";
            response.Message = $"Error: {ex.Message}";
        }

        return await Task.FromResult(response);
    }
}