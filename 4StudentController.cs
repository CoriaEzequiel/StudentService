using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YourApp.Models;
using YourApp.Services;

namespace YourApp.Controllers       //llama al método _students del servicio (StudentServices) 
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
                return NotFound(); //el servidor devuelve respuesta HTTP 404 que no fue encontrado
            }
            return Ok(student);
        }

        [HttpPost]      //método de acción que toma un objeto Student llamado newStudent como parámetro
        public ActionResult<Student> CreateStudent(Student newStudent) 
        {
             if (!ModelState.IsValid) //ModelState comprueba si los datos del modelo son válidos ( propiedad del controlador)
    {
        return BadRequest(ModelState);  
    }
            _studentService.CreateStudent(newStudent);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")] //responderá a la ruta       
        public IActionResult UpdateStudent(int id, Student updatedStudent) //toma un ID de estudiante y un objeto Student llamado updatedStudent
        {
            if (id != updatedStudent.Id) //a verifica si el ID proporcionado en la ruta con el del estudiante
            {
                return BadRequest(); // si no coincide  arroja 400
            }
            _studentService.UpdateStudent(updatedStudent);      //sino llama  al método updateStudent para actualizar
            return NoContent();     // si sale todo bien devuelve 204: indica que la operación fue exitosa.
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}



//GET: Este método se utiliza para solicitar datos de un recurso especificado.
// No modifica ningún dato en el servidor.



//POST: Este método se utiliza para enviar datos para ser procesados => a un recurso especificado.
// Los datos se incluyen en el cuerpo de la solicitud. 
//Esto puede resultar en la creación de un nuevo recurso o los datos pueden ser enviados para su almacenamiento.

// creacion de un nuevo estudiante. 
// almacenar en una base de datos.



//PUT: Este método se utiliza para actualizar un recurso existente con datos nuevos.
// Al igual que POST, los datos se incluyen en el cuerpo de la solicitud.