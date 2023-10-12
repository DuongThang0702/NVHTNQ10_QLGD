using Business.Dtos;
using Business.Services.Auth;
using Microsoft.AspNetCore.Authorization;
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
            var response = await _authService.SignUp(data);
            if (!response.Succeeded)
                return BadRequest(response);
            else
                return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInDto data)
        {
            var response = await _authService.SignIn(data);
            if (response.Status == false)
                return BadRequest(response);
            else
                return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto payload)
        {
            var response = await _authService.ResetPassword(payload);
            if (!response.Succeeded)
                return BadRequest(response);
            else
                return Ok(response);
        }
    }
}
