using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;


namespace HCI_projekat_2020
{
    [Serializable]
    public class EtiketaDogadjaja
    {
        public string oznaka { get; set; }
        public string boja { get; set; }
        public string opis { get; set; }

        public EtiketaDogadjaja()
        {

        }

        public EtiketaDogadjaja(string ozn, string boja, string op)
        {
            this.oznaka = ozn;
            this.boja = boja;
            this.opis = op;
        }
    }
}
