using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyApi.Domain.Model;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/{controller}/v{version:ApiVersion}")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, 
                                        SignInManager<IdentityUser> signInManager,
                                        IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Registrar novo usuário
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserVO vo)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            {
                UserName = vo.Email,
                Email = vo.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, vo.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);
            return Ok(GerarToken(vo));

        }

        /// <summary>
        /// Realizar autenticação 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserVO userInfo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(GerarToken(userInfo));
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Login inválido!");
                return BadRequest();
            }
        }

        private object GerarToken(UserVO userInfo)
        {
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Thilisbleibous", "Shidoublirous"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var credentialsExpiration = _configuration["TokenConfiguration:ExpireHours"];
            var expireToken = DateTime.UtcNow.AddHours(double.Parse(credentialsExpiration));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claim,
                expires: expireToken,
                signingCredentials: credentials
                );

            return new TokenUser()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expireToken,
                Message = "Jwt Ok"
            };
        }
    }
}
