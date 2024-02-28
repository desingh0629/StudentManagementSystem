using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Interface;
using StudentManagementSystem.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //[Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Create a new student", Description = "Creates a new student record.")]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<Student>))]
        public async Task<ActionResult> GetAllStudent()
        {
            return Ok(await _studentService.GetAllStudents());
        }
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get student by ID", Description = "Retrieves a student record by its unique identifier.")]
        [SwaggerResponse(200, "Success", typeof(Student))]
        [SwaggerResponse(404, "Not Found", null)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentById(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }

        [HttpPost()]
        [SwaggerOperation(Summary = "Create a new student", Description = "Creates a new student record.")]
        [SwaggerResponse(201, "Created", typeof(Student))]
        [SwaggerResponse(400, "Bad Request", typeof(ValidationProblemDetails))]
        public async Task<ActionResult> CreateStudent([FromBody] Student student)
        {
            var createdStudent = await _studentService.CreateStudent(student);
            return Ok(createdStudent);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing student", Description = "Updates an existing student record.")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request", typeof(ValidationProblemDetails))]
        [SwaggerResponse(404, "Not Found", null)]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
           var data = await _studentService.UpdateStudent(id, student);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a student", Description = "Deletes a student record by its unique identifier.")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(404, "Not Found", null)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            
            var data  = await _studentService.DeleteStudent(id);
            return Ok(data);
        }
    }
}
