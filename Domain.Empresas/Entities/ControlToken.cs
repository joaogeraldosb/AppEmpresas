﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class ControlToken : BaseEntity
    {
        public ControlToken() { }

        public Int64 Id { get; set; }
        public String Token { get; set; }
        public string Client { get; set; }
        public DateTime SolicitationDate { get; set; }
        public DateTime? AuthenticationDate { get; set; }
        public int IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
