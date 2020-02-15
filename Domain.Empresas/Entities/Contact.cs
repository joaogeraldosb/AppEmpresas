using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Entities
{
    public class Contact
    {
        public Contact() { }
        public Contact(string name
            , string phone
            , string cellPhone
            , string email)
        {
            ContactName = name;
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
        }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
