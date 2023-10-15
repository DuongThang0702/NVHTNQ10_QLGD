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
            if (response.Status == false)
                return BadRequest(new { Mes = "Something went wrong" });
            else
                return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUser([FromRoute] string id)
        {
            var response = await _userService.GetOneUser(id);
            if (response == null) return BadRequest("User not found");
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfoUser([FromBody] UpdateInfoUserDto data, [FromRoute] string id)
        {
            var response = await _userService.UpdateUser(id, data);
            if (!response.Succeeded)
                return BadRequest(response);
            else return Ok(response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var response = await _userService.DeleteUser(userId);
            if (!response.Succeeded)
                return BadRequest(response);
            else
                return Ok(response);
        }
    }
}
