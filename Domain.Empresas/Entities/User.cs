using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class User : BaseEntity
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Byte[] Senha { get; set; }
        public DateTime? UltimoLogin { get; set; }

    }
}
