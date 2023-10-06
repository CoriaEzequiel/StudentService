using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YourApp.Models;
using YourApp.Services;

namespace YourApp.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;       //INYECCIÓN DE DEPENDENCIAS  - variable _studentService (Para accedera los métodos)
                                                            // La inyección se realiza a través del constructor.
        public StudentController(IStudentService studentService) //Este es el constructor(de Iny) del controlador StudentController
        {                       //IStudentService se pasa por parámetro al constructor
            _studentService = studentService;   //(aqui estamos dentro del constructor)
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student newStudent)
        {
            _studentService.CreateStudent(newStudent);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            if (id != updatedStudent.Id)
            {
                return BadRequest();
            }
            _studentService.UpdateStudent(updatedStudent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}