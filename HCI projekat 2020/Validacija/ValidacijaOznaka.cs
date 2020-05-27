using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;


namespace HCI_projekat_2020.Validacija
{
    public class ValidacijaOznaka : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = value.ToString();

            if(string.Equals(content, "Unesite oznaku..."))
            {
                return new ValidationResult(true, null);
            }
            else if (string.Equals(content, "Unesite troškove..."))
            {
                return new ValidationResult(true, null);
            }
            else if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "Polje ne sme biti prazno!");
            }
            else //if (Int32.TryParse(value.ToString(), out cap))
            {
                return new ValidationResult(true, null);
            }
            /*
            else
            {
                return new ValidationResult(false, "Vrednost mora biti BROJ!");
            }*/
        }
    }
}
