using Microsoft.AspNetCore.Mvc;
using MongoDbCrudApp.Models;
using MongoDbCrudApp.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService; 
        }


        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _studentService.GetAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student student)
        {
            await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Student student)
        {
            await _studentService.UpdateAsync(id, student);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentService.RemoveAsync(id);
            return NoContent();
        }
    }
}
