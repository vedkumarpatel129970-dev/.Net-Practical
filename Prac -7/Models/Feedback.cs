
using System.ComponentModel.DataAnnotations;

namespace Practical7.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Please enter your enrollment number.")]
        [StringLength(20, ErrorMessage = "Enrollment number cannot exceed 20 characters.")]
        public string EnrollmentNumber { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please select a subject.")]
        public string Subject { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [StringLength(300, ErrorMessage = "Comment cannot exceed 300 characters.")]
        public string Comment { get; set; }
    }
}
