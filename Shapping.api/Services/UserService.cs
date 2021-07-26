using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shapping.api.Entities;
using Shapping.api.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.api.Services
{
    public class UserService:IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = 1, FirstName = "Sina", LastName = "Riyahi", Username = "admin", Password = "1234",
                Role = "Admin"
            },
            new User
            {
                Id = 2, FirstName = "Nima", LastName = "Riyahi", Username = "User", Password = "1234",
                Role = "User"
            }
        };
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

           
            if (user == null)
                return null;

           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaims(new[]
            {
                new Claim(ClaimTypes.Role, user.Role.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }
    }
}
   