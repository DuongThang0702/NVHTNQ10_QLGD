using Business.Dtos;
using Business.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _userService.GetAllUser();
            if (response.Status == false) return BadRequest(new { Mes = "Something went wrong" });
            else return Ok(response);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto payload, [FromRoute] string userId)
        {
            var response = await _userService.ResetPassword(payload, userId);
            if (response.Status == false) return BadRequest(response);
            else return Ok(response);
        }
    }
}
