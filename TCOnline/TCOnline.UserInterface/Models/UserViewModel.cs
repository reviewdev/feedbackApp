using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TCOnline.UserInterface.Models
{
    public class UserViewModel : IValidatableObject
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(UserName))
                yield return new ValidationResult("User Name field is required", new string[] { nameof(UserName) });

            if (string.IsNullOrEmpty(Password))
                yield return new ValidationResult("Password field is required", new string[] { nameof(Password) });

        }
    } // end of class
}