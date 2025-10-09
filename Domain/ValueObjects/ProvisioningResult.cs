using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class ProvisioningResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string ResourceId { get; private set; }

        private ProvisioningResult(bool success, string message, string resourceId = "")
        {
            Success = success;
            Message = message;
            ResourceId = resourceId;
        }

        public static ProvisioningResult Ok(string resourceId, string message = "Provisioning successful")
            => new(true, message, resourceId);

        public static ProvisioningResult Fail(string message = "Provisioning Failed")
       => new(false, message);

    }
}
