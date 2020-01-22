using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CatsWpf.ValidationRules
{
    class BirthNotInTheFutureRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (((DateTime)value) > DateTime.Now)
            {
                return new ValidationResult(false, Message);
            }
            return ValidationResult.ValidResult;
        }

        public String Message = "Choose date that is not in the future!";
    }
}
