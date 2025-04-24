using LT.Domain.Entities;
using LT.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LT.Application.Interfaces;

namespace LT.Infrastructure.Security
{
    public class JwtAuthService : IAuthService
    {
        private readonly JwtOptions _opts;
        public JwtAuthService(IOptions<JwtOptions> opts) => _opts = opts.Value;

        public string GenerateToken(User user)
        {
            var claims = new[] { new Claim("sub", user.Id.ToString()), /* ... */ };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opts.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                    issuer: _opts.Issuer,
                    audience: _opts.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_opts.ExpireMinutes),
                    signingCredentials: creds
            ));
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
