using System;
using System.ComponentModel.DataAnnotations;

namespace Pro_MVC_25_ModelValidation.Infrastructure
{
    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && (DateTime)value > DateTime.Now;
        }
    }
}