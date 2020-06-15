using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HCI_projekat_2020
{
    [Serializable]
    public class Dogadjaj
    {
        public string oznaka { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string drzava { get; set; }
        public string grad { get; set; }
        public string troskovi_odrzavanja { get; set; }
        public string tip { get; set; }
        public string etiketa { get; set; }
        public string posecenost_dogadjaja { get; set; }
        public string humanitarnog_karaktera { get; set; }
        public string ikonica { get; set; }
        public string datum_odrzavanja { get; set; }
        public List<String> istorija_odrzavanja { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        
        public Dogadjaj(string ozn, string naz, string op, string tip, string etiketa, string pos, string hum, string ik, string tros, string drz, string gr, string dat, List<String> ist)
        {
            this.oznaka = ozn;
            this.naziv = naz;
            this.opis = op;
            this.tip = tip;
            this.posecenost_dogadjaja = pos;
            this.humanitarnog_karaktera = hum;
            this.ikonica = ik;
            this.troskovi_odrzavanja = tros;
            this.drzava = drz;
            this.grad = gr;
            this.datum_odrzavanja = dat;
            this.etiketa = etiketa;
            this.istorija_odrzavanja = ist;
        }

        public Dogadjaj()
        {

        }
    }
}
