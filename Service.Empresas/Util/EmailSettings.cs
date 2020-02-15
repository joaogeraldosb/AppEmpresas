using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Empresas.Util
{
    public class EmailSettings
    {
        public string Signature { get; set; }
        public string Email { get; set; }
        public bool EnableSSL { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
