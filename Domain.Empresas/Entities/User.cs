using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class User : BaseEntity
    {
        public User(){ }

        public int Id { get; set; }
        public String Name { get; set; }
        public Byte[] Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual ICollection<ControlToken> Tokens { get; set; }
    }
}
