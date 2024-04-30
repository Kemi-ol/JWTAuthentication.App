using Authentication.Model;
using Authentication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthTokenController : ControllerBase
    {

        public IConfiguration _configuration;

        private readonly DatabaseContext _databaseContext;

       public AuthTokenController(DatabaseContext databaseContext,
           IConfiguration configuration)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        [HttpPost]
        public async Task<IActionResult> AddUserInfo(UserInfo _userData)
        {    
            if (_userData!= null && _userData.Email != null && _userData.Password != null )
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                   
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,

                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // login for claim based on gender and age

        [HttpPost("login")]
        public async Task<IActionResult> Login(string gender, int age)
        {
            try
            {
                //// Null check for gender
                //if (gender is null)
                //{
                //    return BadRequest("Gender is required.");
                //}


                // Create claims based on the provided gender and age
                var claims = new List<Claim>
                {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("gender", gender), // Use the provided gender
            new Claim("age", age.ToString()) // Use the provided age

                };

            var token = await GenerateJwtTokenAsync(claims);
                return Ok(token);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        private async Task<string> GenerateJwtTokenAsync(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,

                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        private async Task<UserInfo?> GetUser(string email, string password)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }


    }
}
