using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi.Services
{
    public class TokenService : ITokenService
    {
        public string GenerationToken(ModeloUsuarioClienteVerificacaoDto Usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("asfsdfgbsdfhfgjhj!*");

            var tokenDescriptor = new SecurityTokenDescriptor() {

                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, Usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, Usuario.Role.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);

        }
    }
}
