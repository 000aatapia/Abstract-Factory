using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.DTOs
{
    public class ProvisioningRequestDto
    {
        public string Provider {  get; set; } = string.Empty;
        public string VmName {  get; set; } = string.Empty;


        public Dictionary<string, string> NetworkParameters { get; set; } = new();
        public Dictionary<string,string> StorageParameters { get;set; } = new();
    }
}
