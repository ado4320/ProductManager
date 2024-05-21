using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using ProductManager.Core.Services.Dtos;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces.Services;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;


namespace ProductManager.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private IMapper Mapper { get; }
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IMapper mapper, IConfiguration config)
        {
            _authService = authService;
            Mapper = mapper;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDto userLogin)
        {
            try
            {
                if (userLogin == null)
                {
                    return BadRequest("Invalid Client Request");
                }

                var response = _authService.ValidationUser(Mapper.Map<User>(userLogin));
                var user = Mapper.Map<RolDto>(response);

                if (response != null)
                {
                    return Ok(GenerateJWT(response));
                }
                return Unauthorized("Invalid credentials");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string GenerateJWT(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "rol"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
