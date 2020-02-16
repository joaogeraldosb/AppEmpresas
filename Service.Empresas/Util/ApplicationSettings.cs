using Service.Empresas.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Util.Settings;

namespace Services.Empresas.Util
{
    /// <summary>
    /// ApplicationSettings
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Url of endpoint to get files
        /// </summary>
        public string Arquivo { get; set; }
        /// <summary>
        /// Online email sending settings
        /// </summary>
        public EmailSettings Email { get; set; }

        /// <summary>
        /// Token Settings
        /// </summary>
        public TokenSettings Token { get; set; }

    }
}
