using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Security.Jwt
{/// <summary>
/// Erişim Anahtarı
/// </summary>
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }//Token süresi

    }
}
