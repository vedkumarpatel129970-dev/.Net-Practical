using System.ComponentModel.DataAnnotations;

namespace Practical8.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the product name.")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Range(0, 1000000, ErrorMessage = "Quantity must be zero or more.")]
        public int Quantity { get; set; }

        [Range(typeof(decimal), "0.01", "99999999", ErrorMessage = "Enter a valid price greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a category.")]
        [StringLength(60)]
        public string Category { get; set; }
    }
}