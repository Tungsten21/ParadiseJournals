using System.ComponentModel.DataAnnotations;

namespace ViewModels.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateComparatorAttribute : ValidationAttribute
    {
        private readonly CompareMode _compareMode;
        private readonly string _dateToCompareFieldName;

        public DateComparatorAttribute(CompareMode compareMode, string dateToCompareFieldName)
        {
            _compareMode = compareMode;
            _dateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (_compareMode == CompareMode.LessThan)
            {
                DateOnly beforeDate = DateOnly.Parse((string)value);

                string? afterDateString = (string?)validationContext.ObjectType.GetProperty(_dateToCompareFieldName)
                    .GetValue(validationContext.ObjectInstance);

                bool afterDateSet = afterDateString != null;

                if (afterDateSet && beforeDate < DateOnly.Parse(afterDateString) || !afterDateSet)
                    return ValidationResult.Success;

                ErrorMessage = "AHAHAHAHA";
                return new ValidationResult("Start Date must be earlier than the End Date.");

            }
            else
            {
                string? beforeDateString = (string?)validationContext.ObjectType.GetProperty(_dateToCompareFieldName)
                    .GetValue(validationContext.ObjectInstance);

                DateOnly afterDate = DateOnly.Parse((string) value);

                bool beforeDateSet = beforeDateString != null;

                if (beforeDateSet && afterDate > DateOnly.Parse(beforeDateString) || !beforeDateSet)
                    return ValidationResult.Success;

                ErrorMessage = "AHAHAHAHA2";
                return new ValidationResult("End Date must be after the Start Date.");
            }


        }


    }
}
