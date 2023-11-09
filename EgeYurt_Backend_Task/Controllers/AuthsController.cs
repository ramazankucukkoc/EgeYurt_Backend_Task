using EgeYurt_Backend_Task.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgeYurt_Backend_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand )
        {
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            return Ok(registeredDto.AccessToken);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand )
        {
            LoginDto loginDto  = await Mediator.Send(loginCommand);
            return Ok(loginDto.AccessToken);
        }
    }
}
