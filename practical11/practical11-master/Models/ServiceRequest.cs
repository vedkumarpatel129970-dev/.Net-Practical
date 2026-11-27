using System.ComponentModel.DataAnnotations;

namespace practical11.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student name is required.")]
    [StringLength(70, ErrorMessage = "Student name cannot exceed 70 characters.")]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    [StringLength(60, ErrorMessage = "Department cannot exceed 60 characters.")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Issue is required.")]
    [StringLength(80, ErrorMessage = "Issue cannot exceed 80 characters.")]
    public string Issue { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Status is required.")]
    [StringLength(50)]
    public string Status { get; set; } = "Pending";

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
