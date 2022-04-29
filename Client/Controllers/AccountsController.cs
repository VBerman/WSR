using Client.Extensions;
using Client.Data.Auth;
using Client.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DB _DB;
        private readonly IConfiguration _configuration;
        public AccountsController(IConfiguration configuration, DB DB)
        {
            _DB = DB;
            _configuration = configuration;
        }

        [HttpPost]
     
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _DB.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).AsAsyncEnumerable().FirstOrDefaultAsync(u => u.Login == loginModel.Login);

            if (user == null || user.Password != loginModel.Password.ToMD5Hash())
            {
                return BadRequest(new LoginResult { Successful = false, Error = "Login or password incorrect" });
            }
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(_configuration["JWT:Expiry"]));

            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                signingCredentials: credentials,
                expires: expiry
            );

            return Ok(new LoginResult
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }

    }
}
