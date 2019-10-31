using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCOnline.UserInterface.Models
{
    public class FeedbackViewModel: IValidatableObject
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           
            if (!string.IsNullOrEmpty(Comment) && Comment.Length > 250)
                yield return new ValidationResult("Maximum characters for Comment field is 250", new string[] { nameof(Comment) });
            if (Rating == null)
                yield return new ValidationResult("Rating field is required", new string[] { nameof(Rating) });


        }

    } // end of class
}