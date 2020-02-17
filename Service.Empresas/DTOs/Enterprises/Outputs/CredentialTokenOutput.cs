using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public class CredentialTokenOutput
    {
        [JsonProperty("uid")] public int Id { get; set; }
        [JsonProperty("access-token")] public string AccessToken { get; set; }
        [JsonProperty("client")] public string Client { get; set; }
    }
}
