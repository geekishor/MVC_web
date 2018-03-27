using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_web.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5, ErrorMessage = "Last name should not be greater than 5")]
        public string LastName { get; set; }
        public int Salary { get; set; }


    }

    public class FirstNameValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Please provide firt name..");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First name should not contain @");
                }
            }
            return ValidationResult.Success;
        }
    }

}