using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Inputs
{
    public partial class EnterpriseFilter
    {
        [FromQuery(Name = "name")] public string Name { get; set; }
        [FromQuery(Name = "enterprise_types")] public int? IdEnterpriseType { get; set; }

    }
}
