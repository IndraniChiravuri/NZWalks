using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> identityUserManager;
        private readonly IJwtTokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> identityUserManager, IJwtTokenRepository tokenRepository)
        {
            this.identityUserManager = identityUserManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerUser)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Username
            };

            var identityResult = await identityUserManager.CreateAsync(identityUser, registerUser.Password);
            if (identityResult.Succeeded)
            {
                if (registerUser != null && registerUser.Roles.Any())
                    identityResult = await identityUserManager.AddToRolesAsync(identityUser, registerUser.Roles);
                if (identityResult.Succeeded)
                    return Ok("User Registered! Please login");
            }

            return BadRequest("Something Went Wrong! Please check request");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await identityUserManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPwd = await identityUserManager.CheckPasswordAsync(user,loginRequestDto.Password);
                if (checkPwd)
                {
                    var roles = await identityUserManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                       var token =  _tokenRepository.CreateJwtToken(user, roles.ToList());
                        return Ok(token);
                    }
                }
            }

            return BadRequest("Incorrect Username or Password!");
        }
    }
}
