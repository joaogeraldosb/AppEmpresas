using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Service.Empresas.DTOs.Enterprises.Inputs
{
    public class UserInput
    {
        public UserInput(string name, string password)
        {
            Name = name;
            var hasher = new SHA512Managed();
            Password = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Byte[] Password { get; }
    }
}
