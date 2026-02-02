using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.Common.Validation
{
    public sealed class EnumValueAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValueAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (!Enum.IsDefined(_enumType, value))
                return new ValidationResult(ErrorMessage ?? "Valor inválido");

            return ValidationResult.Success;
        }
    }
}
