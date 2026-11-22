using Microsoft.AspNetCore.Mvc;
using Practical10.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practical10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Mayur Chavda", Email = "mayur@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Id = 2, Name = "Prit Pansuriya", Email = "prit@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Id = 3, Name = "Kirtan Chauhan", Email = "kirtan@gmail.com", Course = "Computer Engineering", Semester = 5 },
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Id = students.Count == 0 ? 1 : students.Max(s => s.Id) + 1;
            students.Add(student);

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Course = updatedStudent.Course;
            student.Semester = updatedStudent.Semester;

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            students.Remove(student);

            return Ok("Student deleted successfully");
        }
    }
}
