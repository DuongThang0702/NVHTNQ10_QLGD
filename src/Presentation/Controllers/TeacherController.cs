using Business.Dtos;
using Business.Services.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var response = await _teacherService.GetAllTeacher();
            if(response == null) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto data)
        {
            var response = await _teacherService.CreateTeacher(data);
            if(!response.Succeeded) return BadRequest(response);    
            else return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfo([FromBody] UpdateInfoTeacherDto data, [FromRoute] string idUser)
        {
            var response = await _teacherService.UpdateInfo(data, idUser);
            if(!response.Succeeded) return BadRequest(response);
            else return Ok(response);   
        }
    }
}
