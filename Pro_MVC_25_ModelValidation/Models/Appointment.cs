using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Pro_MVC_25_ModelValidation.Infrastructure;

namespace Pro_MVC_25_ModelValidation.Models
{
    [NoJoeOnMondays]
    public class Appointment //: IValidatableObject
    {
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 3)]
        public string ClientName { get; set; }
        //[DataType(DataType.Date)]
        //[FutureDate(ErrorMessage = "Please enter a date in the future")]
        [Remote(action: "ValidateDate", controller: "Home")]
        public DateTime Date { get; set; }
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var errors = new List<ValidationResult>();
        //    if (string.IsNullOrEmpty(ClientName))
        //    {
        //        errors.Add(new ValidationResult("Please enter your name"));
        //    }
        //    if (DateTime.Now > Date)
        //    {
        //        errors.Add(new ValidationResult("Please enter date in the future"));
        //    }
        //    if (errors.Count == 0 &&
        //        ClientName.Equals("joe", StringComparison.OrdinalIgnoreCase) &&
        //        Date.DayOfWeek == DayOfWeek.Monday)
        //    {
        //        errors.Add(new ValidationResult("Joe cannot book appointments on Mondays"));
        //    }
        //    if (!TermsAccepted)
        //    {
        //        errors.Add(new ValidationResult("You must accept the terms"));
        //    }
        //    return errors;
        //}
    }
}