using BankAtm.DTOS;
using BankAtm.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankAtm.Entities;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        private readonly IUserService userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] AuthRequest request)
        {
            AuthResponse authResponse = null;
            User? user = userService.Validate(request.Email, request.Password);

            if (user != null)
            {
                string jwtToken = GetToken(user);
                authResponse = new AuthResponse()
                {
                    Email = user.Email,
                    Role = user.Role,
                    Token = jwtToken

                };


            }

            return StatusCode(200, authResponse);
        }

        private string GetToken(User? user)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );

            var subject = new ClaimsIdentity(new[]
            {
                        new Claim(ClaimTypes.Name,user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    });

            var expires = DateTime.UtcNow.AddMinutes(10); //expire time

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
