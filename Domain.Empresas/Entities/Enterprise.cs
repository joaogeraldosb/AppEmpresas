using Domain.Empresas.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class Enterprise : BaseEntity
    {
        protected Enterprise() { }

        public Enterprise(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int IdEnterpriseType { get; set; }

        public virtual EnterpriseType EnterpriseType { get; set; }
        public Contact Contact { get; set; } = new Contact();

    }
}
