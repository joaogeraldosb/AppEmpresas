using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Inputs
{
    public class CredentialInput
    {
        [FromQuery(Name = "email")] public string Email { get; set; }
        [FromQuery(Name = "password")] public string Password { get; set; }
    }
}
