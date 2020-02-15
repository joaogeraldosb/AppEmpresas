using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public partial class EnterpriseTypeOutput
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("enterprise_type_name")]
        public string Name { get; set; }
        [JsonProperty("enterprise_type_description")]
        public string Description { get; set; }

    }
}
