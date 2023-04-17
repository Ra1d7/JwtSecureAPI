using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GettingStartedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }
        public record AuthenticationData(string? UserName, string? Password);
        public record UserData(int Id, string Username, string Title , string EmployeeId);
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
        {
            var user = IsValid(data);
            if (user == null) return Unauthorized();
            return GenerateToken(user);
        }

        private UserData? IsValid(AuthenticationData data)
        {
            //THIS IS DEMO CODE - I Won't Actually Use This In A Production Enviroment
            if (data != null)
            {
                if (data.UserName == "Moath" && data.Password == "test123")
                {
                    return new UserData(1, data.UserName, "Head of Security", "E001");
                }
                if (data.UserName == "Morad" && data.Password == "mor123")
                {
                    return new UserData(2, data.UserName, "Human Resources Officer", "E005");
                }
                if (data.UserName == "Hothefa" && data.Password == "Hoth123")
                {
                    return new UserData(3, data.UserName, "Business Owner", "E000");
                }
            }
            return null;
        }

        private string GenerateToken(UserData user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Username));
            claims.Add(new("title", user.Title));
            claims.Add(new("emp_id", user.EmployeeId));

            var tokenbuild = new JwtSecurityToken(
                _config.GetValue<string>("Authentication:Issuer"),
                _config.GetValue<string>("Authentication:Audience"),
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(1),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenbuild);

        }
    }
}
