using Business.Dtos;
using Business.Services.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRoles());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto payload)
        {
            var response = await _roleService.CreateRole(payload);
            if (response.Status == false)
                return BadRequest(response);
            else
                return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRole(
            [FromBody] UpateRoleDto data,
            [FromQuery] string roleId
        )
        {
            var response = await _roleService.UpdateRole(data, roleId);
            if (response.Status == false)
                return BadRequest(response);
            else
                return Ok(response);
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole([FromRoute] string roleId)
        {
            var response = await _roleService.DeleteRole(roleId);
            if (response.Status == false)
                return BadRequest(response);
            else
                return Ok(response);
        }
    }
}
