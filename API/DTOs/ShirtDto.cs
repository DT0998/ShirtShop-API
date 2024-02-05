using API.Models.Shirt.Validations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ShirtDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Shirt_EnsureCorrectSizing]
        public string[]? Size { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }

        public int? TotalPrice { private get; set; }

        public int? Quantity { private get; set; }
    }
}
