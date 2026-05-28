using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_1.CustomValidation
{
    public class IDValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value != null)
            {
                string id = value.ToString();
                if (id.All(char.IsDigit))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage);
            }
            return new ValidationResult("ID is required");
        }
    }
}