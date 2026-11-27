using System.ComponentModel.DataAnnotations;

namespace practical11.Models;

public class CampusEvent
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(150, ErrorMessage = "Location cannot exceed 150 characters.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event date is required.")]
    [Display(Name = "Event Date")]
    [DataType(DataType.DateTime)]
    public DateTime EventDate { get; set; } = DateTime.Today.AddDays(7).AddHours(10);

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;
}
