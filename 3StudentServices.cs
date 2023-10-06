using System.Collections.Generic;
using YourApp.Models;
//logica del negocio - sabe como llevar a cabo las operaciones
//contiene los métodos para manejar el CRUD         para luego ser llamados por el controlador StudentController

//Por ejemplo, el método GetAllStudents() en StudentService devuelve una lista de todos los estudiantes.
// El controlador puede llamar a este método para obtener todos los estudiantes cuando se recibe una solicitud HTTP GET.

namespace YourApp.Services          //implementación real de las operaciones definidas en capa de interfaz
{
    public class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>();

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)       //(toma id por parámetro que quiero buscar)
        {
            return _students.Find(student => student.Id == id); //busca un estudiante en la lista
        }                                       //devuelve un objeto student 

        public void CreateStudent(Student newStudent)
        {
            _students.Add(newStudent);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            var index = _students.FindIndex(student => student.Id == updatedStudent.Id);
            if (index != -1)
            {
                _students[index] = updatedStudent;
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _students.Find(student => student.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}