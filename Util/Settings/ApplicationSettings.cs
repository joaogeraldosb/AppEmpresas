using System;
using System.Collections.Generic;
using System.Text;
using Util.Settings;

namespace Util.Settings
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
    }
}
