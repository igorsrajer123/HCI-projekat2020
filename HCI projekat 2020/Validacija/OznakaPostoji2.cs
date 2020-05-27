using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace HCI_projekat_2020.Validacija
{
    class OznakaPostoji2 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = value.ToString();

            for (int i = 0; i < DodajDogadjaj.listaDogadjaja.Count(); i++)
            {
                if (DodajDogadjaj.listaDogadjaja.ElementAt(i).oznaka.Equals(content))
                {
                    return new ValidationResult(false, "Vrednost mora biti JEDINSTVENA!");
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
