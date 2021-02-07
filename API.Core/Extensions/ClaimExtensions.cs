﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email) //this extension yapıyoruz var olan sınıfı genişletiyoruz.
        {
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Email, value: email));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(type: ClaimTypes.Name, value: name));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(type: ClaimTypes.Role, value: role)));

        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(type: ClaimTypes.NameIdentifier, value: nameIdentifier));
        }
    }
}
