using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public class EnterpriseDetailListOutput
    {
        [JsonProperty("enterprise")] 
        public EnterpriseDetailOutput Enterprise { get; set; }
    }
}
