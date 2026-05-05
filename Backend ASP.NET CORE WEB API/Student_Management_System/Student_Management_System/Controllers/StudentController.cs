using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;
using Student_Management_System.DTOs;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext dbContext;
        private string Name;
        private string Phone;
        private string Email;
        private string Course;

        public StudentController(StudentDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllStudent()
        {
            return Ok (dbContext.Students.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetStudentbyId(Guid id)
        {
            var student = dbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
       
        public IActionResult AddStudent(AddStudentDTO dto)
        {
            try
            {
                Console.WriteLine("Course: " + dto.Course);

                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Course = dto.Course
                };

                dbContext.Students.Add(student);
                dbContext.SaveChanges();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateStudent(Guid id,UpdateStudentDTO dto)
        {
            var student=dbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name=dto.Name;
            student.Email=dto.Email;
            student.Phone=dto.Phone;
            student.Course=dto.Course;

            dbContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student= dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok(student);
        }
    }
}
