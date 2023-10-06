using System.Collections.Generic;
using YourApp.Models;

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