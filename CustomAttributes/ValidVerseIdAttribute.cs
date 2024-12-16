using System.ComponentModel.DataAnnotations;

namespace QuranWebApp.CustomAttributes
{
    public class ValidVerseIdAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            if (value is not int verseId)
                throw new ArgumentNullException(nameof(value));

            if (verseId < 1 || verseId > 6348)
                return new ValidationResult("VerseId should be greater than 0 and less than or equal to 6348 ");

            return ValidationResult.Success;
        }
    }
}
