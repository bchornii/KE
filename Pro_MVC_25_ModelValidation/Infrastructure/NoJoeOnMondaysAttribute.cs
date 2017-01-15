using System;
using System.ComponentModel.DataAnnotations;
using Pro_MVC_25_ModelValidation.Models;

namespace Pro_MVC_25_ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Mondays";
        }

        public override bool IsValid(object value)
        {
            var appt = value as Appointment;
            if (string.IsNullOrEmpty(appt?.ClientName))
            {
                return false;
            }
            return !(appt.ClientName.Equals("joe", StringComparison.OrdinalIgnoreCase) &&
                     appt.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}