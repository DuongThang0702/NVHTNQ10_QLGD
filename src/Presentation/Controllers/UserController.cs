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

        [HttpPatch("{userId}")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto payload, [FromRoute] string userId)
        {
            var response = await _userService.ResetPassword(payload, userId);
            if (!response.Succeeded) return BadRequest(response);
            else return Ok(response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var response = await _userService.DeleteUser(userId);
            if (!response.Succeeded) return BadRequest(response);
            else return Ok(response);    
        }
    }
}
