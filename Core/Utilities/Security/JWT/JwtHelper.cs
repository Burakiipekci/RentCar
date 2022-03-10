using Core.Entites.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // Apideki Appsettingsi okumaya yarayacak.
        private TokenOptions _tokenOptions; //Appsettings değerleri bir nesneye atmaya yarayacak.
        private DateTime _accessTokenExpiration; //AccessToken ne zaman geçersizleşicek süre koymaya yarayacak.
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); 
            //Appsettingsdeki ayarları bul , al ve TokenOptions sınıfına ata.

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //Kullanıcı için Token üreticez.
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Tokenın süresinin ne zaman biteceğini alıyoruz (Appsettingsden).
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Kullanacağımız anahtarı alıyoruz.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//Hangi anahtarı algoritmayı kullanacağını söylüyoruz.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//İlgili kullanıcıya atanacak yetenekleri veriyoruz.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            //Bilgileri oluşturuyoruz (appsetting)

            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {

            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());//Roller ekliyoruz.

            return claims;
        }
    }
}
