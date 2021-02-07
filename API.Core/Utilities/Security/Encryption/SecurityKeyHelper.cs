using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string SecurityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)); //symnenic bizim security key imizi oluşturduğumuz 
        }
    }
}
