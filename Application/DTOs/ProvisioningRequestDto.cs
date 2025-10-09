using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;


namespace Application.DTOs
{
    public class ProvisioningRequestDto
    {
        public CloudProvider Provider {  get; set; }
        public string VmName {  get; set; } = string.Empty;


        public Dictionary<string, string> NetworkParameters { get; set; } = new();
        public Dictionary<string,string> Storagearameters { get;set; } = new();
    }
}
