
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.DTOs
{
    public class AddStudentDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Course { get; set; }
    }
}
