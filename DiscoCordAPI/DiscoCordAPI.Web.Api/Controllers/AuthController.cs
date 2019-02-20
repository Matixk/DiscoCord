using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Users;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IAuthRepository repo;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this.repo = repo;
            this.config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            if (await repo.UserExists(userForRegisterDto.Name)) return BadRequest("Username already exists");

            await repo.Register(userForRegisterDto.Name.ToLower(), userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await repo.Login(userForLoginDto.Name.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Name)
            };

            return Ok(new
            {
                token = CreateToken(claims)
            });
        }

        private string CreateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}