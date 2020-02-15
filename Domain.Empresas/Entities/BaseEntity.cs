using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public abstract class BaseEntity
    {
        public virtual bool Active { get; set; }
    }
}
