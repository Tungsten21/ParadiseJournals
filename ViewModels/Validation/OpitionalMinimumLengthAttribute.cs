using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Validation
{
    public class OpitionalMinimumLengthAttribute : ValidationAttribute
    {
        private int _minimumLength;

        public OpitionalMinimumLengthAttribute(int minimumLength)
        {
            _minimumLength = minimumLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value.ToString().Length < _minimumLength)
            {
                return new ValidationResult($"Please enter a value greater than {_minimumLength} characters");
            }

            return ValidationResult.Success;
        }
    }
}
