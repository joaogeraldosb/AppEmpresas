using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public class EnterpriseDetailOutput
    {
        public EnterpriseDetailOutput() {}

        public EnterpriseDetailOutput(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [JsonProperty("id")] 
        public int Id { get; set; }
        [JsonProperty("id")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public DateTime RegistrationDate { get; set; }
        [JsonProperty("id")]
        public int IdEnterpriseType { get; set; }
        [JsonProperty("id")]
        public virtual EnterpriseTypeOutput EnterpriseType { get; set; }
        [JsonProperty("id")]
        public string ContactName { get; set; }
        [JsonProperty("id")]
        public string Phone { get; set; }
        [JsonProperty("id")]
        public string CellPhone { get; set; }
        [JsonProperty("id")]
        public string Email { get; set; }
    }
}

