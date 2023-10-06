using System.Collections.Generic;
using YourApp.Models;

namespace YourApp.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
        void CreateStudent(Student newStudent);
        void UpdateStudent(Student updatedStudent);
        void DeleteStudent(int id);
    }
}