using API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Shirt.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as ShirtDto;
            if (shirt != null && !string.IsNullOrEmpty(shirt.Gender))
            {
                if (shirt.Gender.Equals("Men", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult("For men's shirt,the size has to be greater or equal to 8");
                }
                else if (shirt.Gender.Equals("Women", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult("For women's shirt,the size has to be greater or equal to 6");
                }
            }
            return ValidationResult.Success;
        }
    }
}
