using LimbusCharts.API.Models.DTO;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LimbusCharts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> manager;
        private readonly IJWTTokenRepository jwtTokenRepository;

        public AuthController(UserManager<IdentityUser> manager, IJWTTokenRepository jwtTokenRepository)
        {
            this.manager = manager;
            this.jwtTokenRepository = jwtTokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName  = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName,
            };

            var identityResponce = await manager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResponce.Succeeded)
            {
                if(registerRequestDTO.Roles != null)
                {
                    identityResponce = await manager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResponce.Succeeded)
                        return Ok("User Registered");
                }
            }

            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await manager.FindByEmailAsync(loginRequestDTO.UserName);

            if (user != null){
                var checkResult = await manager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkResult)
                {
                    var roles = await manager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = jwtTokenRepository.CreateJWTToken(user, roles.ToList());

                        var responce = new LoginResponceDTO
                        {
                            JWTToken = jwtToken,
                        };
                        return Ok(responce);
                    }
                }
            }

            return BadRequest("Incorrect username or password");
        }
    }
}
