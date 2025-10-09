using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProvisioningResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ResourceId { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;

        public static ProvisioningResponseDto FromResult(string provider, Domain.ValueObjects.ProvisioningResult result)
        {
            return new ProvisioningResponseDto
            {
                Provider = provider,
                Success = result.Success,
                Message = result.Message,
                ResourceId = result.ResourceId
            };
        }
    }
}
