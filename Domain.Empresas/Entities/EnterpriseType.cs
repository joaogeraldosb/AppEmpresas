using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class EnterpriseType : BaseEntity
    {
        public EnterpriseType(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Enterprise> Enterprises { get; set; }
    }
}
