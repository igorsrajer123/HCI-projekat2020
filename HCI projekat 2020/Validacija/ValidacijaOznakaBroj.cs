using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat_2020.Validacija
{
    class ValidacijaOznakaBroj : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int num = 0;
            string content = value.ToString();
            bool result = int.TryParse(content, out num);

            if (string.Equals(content, "Unesite oznaku..."))
            {
                return new ValidationResult(true, null);
            }
            else if (string.Equals(content, "Unesite troškove..."))
            {
                return new ValidationResult(true, null);
            }
            else if(!result)
            {
                return new ValidationResult(false, "Vrednost mora biti broj!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
