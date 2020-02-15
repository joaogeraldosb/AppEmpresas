using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public partial class EnterpriseListOutput
    {
        [JsonProperty("enterprises")]
        public List<EnterpriseOutput> Enterprises { get; set; }

    }
}
