using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat_2020.Validacija
{
    class NazivPrazan : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = value.ToString();

            if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "Polje ne sme biti prazno!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
