using Domain.Empresas.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public class EnterpriseDetailOutput
    {
        public EnterpriseDetailOutput() {}

        public EnterpriseDetailOutput(Enterprise enterprise)
        {
            Name = enterprise.Name;
            Description = enterprise.Description;
            RegistrationDate = enterprise.RegistrationDate;
            IdEnterpriseType = enterprise.IdEnterpriseType;
            EnterpriseType = new EnterpriseTypeOutput
            {
                Id = enterprise.EnterpriseType.Id,
                Name = enterprise.EnterpriseType.Name
            };
            ContactName = enterprise.Contact.ContactName;
            Phone = enterprise.Contact.Phone;
            CellPhone = enterprise.Contact.CellPhone;
            Email = enterprise.Contact.Email;
        }

        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("registration_date")]
        public DateTime RegistrationDate { get; set; }
        
        [JsonProperty("id_enterprise_type")]
        public int IdEnterpriseType { get; set; }
        
        [JsonProperty("enterprisetype")]
        public virtual EnterpriseTypeOutput EnterpriseType { get; set; }
        
        [JsonProperty("contact_name")]
        public string ContactName { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("cellphone")]
        public string CellPhone { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

