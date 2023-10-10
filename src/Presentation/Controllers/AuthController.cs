using Business.Dtos;
using Business.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto data)
        {
            return Ok(await _authService.SignUp(data));
        }

        [HttpPost]
        public async Task<IActionResult> SignIn()
        {
            return Ok("Ok");
        }

        [HttpDelete]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
