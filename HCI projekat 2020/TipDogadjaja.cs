using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_projekat_2020
{
    [Serializable]
    public class TipDogadjaja
    {
        public string oznaka { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string ikonica { get; set; }
        

        public TipDogadjaja()
        {

        }

        public TipDogadjaja(string ozn, string naz, string op, string ik)
        {
            this.oznaka = ozn;
            this.naziv = naz;
            this.opis = op;
            this.ikonica = ik;
        }
    }
}
