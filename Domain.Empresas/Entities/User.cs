﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string password)
        {
            Name = name;
            var hasher = new SHA512Managed();
            Password = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public Byte[] Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual ICollection<ControlToken> Tokens { get; set; }
    }
}
