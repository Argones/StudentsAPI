using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Services.StudentServices;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            return await _service.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetSingleStudent(int id)
        {
            var result = await _service.GetSingleStudent(id);
            if (result is null)
                return NotFound("Student not found!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            var result = await _service.AddStudent(student);
            return Ok(result);
        }

        [HttpPut("{id}")]        
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request, int id)
        {
            var result = await _service.UpdateStudent(request, id);
            if (result is null)
                return NotFound("Student not found!");
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudent(id);
            if (result is null)
                return NotFound("Student not found!");
            return Ok(result);
        }
    }
}
