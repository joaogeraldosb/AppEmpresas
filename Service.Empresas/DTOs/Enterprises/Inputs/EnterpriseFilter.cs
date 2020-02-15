using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Inputs
{
    public partial class EnterpriseFilter
    {
        [FromQuery(Name = "id")] public int? Id { get; set; }
        [FromQuery(Name = "name")] public string Name { get; set; }
        [FromQuery(Name = "description")] public string Description { get; set; }
        [FromQuery(Name = "registrationDate")] public DateTime RegistrationDate { get; set; }
        [FromQuery(Name = "contactname")] public string ContactName { get; set; }
        [FromQuery(Name = "phone")] public string Phone { get; set; }
        [FromQuery(Name = "cellphone")] public string CellPhone { get; set; }
        [FromQuery(Name = "email")] public string Email { get; set; }
        [FromQuery(Name = "enterprise_types")] public int? EnterpriseTypeId { get; set; }

    }
}
