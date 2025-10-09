using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProvisioningResponseDto
    {
        public string VmId { get; set; } = string.Empty;
        public string NetworkId {  get; set; } = string.Empty;
        public string StorageId { get; set; } = string.Empty;
        public string Status { get; set; } = "Failed";
        public string Message { get; set; } = string.Empty;
    }
}
