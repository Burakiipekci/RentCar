using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // Hangi anahtarı kullanacamızı ve hangi algoritmayı kullanacağımızı belirledik.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securiyKey)
        {
            return new SigningCredentials(securiyKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
