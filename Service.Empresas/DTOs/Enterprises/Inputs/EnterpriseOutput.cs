using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Service.Empresas.DTOs.Enterprises.Inputs
{
    public class EnterpriseOutput
    {
        [JsonProperty("id")] public long? Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("registrationdate")] public DateTime RegistrationDate { get; set; }
        [JsonProperty("phone")] public string Phone { get; set; }
        [JsonProperty("Cellphone")] public string CellPhone { get; set; }
        [JsonProperty("enterprise_type")] public int? EnterpriseTypeId { get; set; }

    }
}
