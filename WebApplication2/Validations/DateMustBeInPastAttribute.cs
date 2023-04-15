using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Validations
{
    public class DateMustBeInPastAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is DateTime date && date < DateTime.Now;
            //var date = value as DateTime?;
            //if (date == null) { return false; }
            //if(date < DateTime.Now) { return true; }
            //else { return false; }

        }
    }
}
