using Azure.Core;
using Backend.Data;
using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services
{
    public class AuthServices:IAuthServices
    {
        private readonly AddDBContext _context;
        private readonly IConfiguration _configuration;
        public AuthServices(AddDBContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Users?> Register(CreateUserPayload payload)
        {
            if (await _context.Users.AnyAsync(u => u.name == payload.Name))
            {
                return null;
            }
            var user = new Users();

            var hashedPassword = new PasswordHasher<Users>()
                .HashPassword(user, payload.Password);

            user.name = payload.Name;
            user.password = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<String?> Login(LoginDto payload)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.name == payload.Username);
            if (user is null)
            {
                return null;
            }
            var passwordVerificationResult = new PasswordHasher<Users>().VerifyHashedPassword(user, user.password, payload.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }
            string token = CreateTokens(user);
            return token;
        }

        private string CreateTokens(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.name),
                new Claim(ClaimTypes.NameIdentifier,user.ID.ToString()),
                new Claim(ClaimTypes.)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptors = new JwtSecurityToken(
                issuer: _configuration.GetValue<String>("AppSettings:Issuer"),
                audience: _configuration.GetValue<String>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptors);
        }
    }
}
