using System.ComponentModel.DataAnnotations;

namespace Pro_MVC_25_ModelValidation.Infrastructure
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) =>
            value is bool && (bool) value;
    }
}