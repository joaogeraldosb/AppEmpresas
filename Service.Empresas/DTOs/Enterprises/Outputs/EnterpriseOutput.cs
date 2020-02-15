using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public partial class EnterpriseOutput
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("enterprise_name")] public string Name { get; set; }
        [JsonProperty("description")] public DateTime RegistrationDate { get; set; }
        //[JsonProperty("enterprise_type")] public EnterpriseTypeOutput EnterpriseType { get; set; }
        [JsonProperty("email_enterprise")] public string Email { get; set; }
        [JsonProperty("contactname")] public string ContactName { get; set; }
        [JsonProperty("phone")] public string Phone { get; set; }
        [JsonProperty("cellphone")] public string CellPhone { get; set; }
        [JsonProperty("email")] public string email { get; set; }
    }
}
