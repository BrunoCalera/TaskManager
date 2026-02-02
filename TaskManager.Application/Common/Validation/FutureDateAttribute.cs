using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.Common.Validation
{
    public sealed class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime dateTimeValue)
                return new ValidationResult("Data inválida");

            if (dateTimeValue < DateTime.Today)
                return new ValidationResult(ErrorMessage ?? "A data não pode ser no passado");

            return ValidationResult.Success;
        }
    }
}
