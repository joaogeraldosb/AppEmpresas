using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Outputs
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
