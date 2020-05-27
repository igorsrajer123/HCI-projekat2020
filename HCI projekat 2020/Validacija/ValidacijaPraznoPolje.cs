using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat_2020.Validacija
{
    class ValidacijaPraznoPolje : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = value.ToString();
            if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "Polje ne sme biti prazno!");
            }
            else if (string.Equals(content, "Unesite opis..."))
            {
                return new ValidationResult(true, null);
            }
            else if (string.Equals(content, "Unesite naziv..."))
            {
                return new ValidationResult(true, null);
            }
            else if (string.Equals(content,"Unesite grad..."))
            {
                return new ValidationResult(true, null);
            }
            else if(string.Equals(content,"Unesite državu..."))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
