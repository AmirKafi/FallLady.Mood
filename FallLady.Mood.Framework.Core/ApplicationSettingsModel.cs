using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Framework.Core
{
    public class ApplicationSettingsModel
    {
        public string Jwt_SecretKey { get; set; }
        public string Jwt_Issuer { get; set; }
        public string Jwt_Audience { get; set; }
        public int ExpiresOn { get; set; }
        public string Api_key { get; set; }
    }
}
