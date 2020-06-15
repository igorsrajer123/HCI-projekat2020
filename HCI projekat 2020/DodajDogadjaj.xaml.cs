using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Shapes;
using HCI_projekat_2020.Help;

namespace HCI_projekat_2020
{
    public struct dogadjaj
    {
        public string oznaka { get; set; }
        public string naziv { get; set; }
        public string troskovi_odrzavanja { get; set; }
        public string drzava { get; set; }
        public string grad { get; set; }
        public string opis { get; set; }
        public string tip { get; set; }
    }

    /// <summary>
    /// Interaction logic for DodajDogadjaj.xaml
    /// </summary>
    public partial class DodajDogadjaj : Window
    {
        public dogadjaj ret()
        {
            dogadjaj d = new dogadjaj();
            d.naziv = "Unesite naziv...";
            d.oznaka = "Unesite oznaku...";
            d.troskovi_odrzavanja = "Unesite troškove...";
            d.grad = "Unesite grad...";
            d.drzava = "Unesite državu...";
            d.opis = "Unesite opis...";
            d.tip = "Odaberite...";

            return d;
        }

        private string filePath;
        public static ObservableCollection<Dogadjaj> listaDogadjaja = new ObservableCollection<Dogadjaj>();
        
        public DodajDogadjaj()
        {
            InitializeComponent();
            // this.DataContext = this;
            DataContext = ret();

            //Otvaranje fajla tipova
            FileStream stream1 = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bin1 = new BinaryFormatter();
            DodajTip.listaTipova = (ObservableCollection<TipDogadjaja>)bin1.Deserialize(stream1);
            comboTip.ItemsSource = DodajTip.listaTipova;
            stream1.Close();

            //Otvaranje fajla etiketa
            FileStream stream2 = new FileStream("data2.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bin2 = new BinaryFormatter();
            DodajEtiketu.listaEtiketa = (ObservableCollection<EtiketaDogadjaja>)bin2.Deserialize(stream2);
            comboEtikete.ItemsSource = DodajEtiketu.listaEtiketa;
            stream2.Close();

            //Serijalizacija dogadjaja
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            long length = new System.IO.FileInfo(".//.//data1.bin").Length;
            if (length > 0)
                listaDogadjaja = (ObservableCollection<Dogadjaj>)bin.Deserialize(stream);
            if (listaDogadjaja.Count() != 0)
            {
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = listaDogadjaja;
            }
            stream.Close();
        }

        private void ikona_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();
            filePath = dlg.FileName;

            if (result == true)
            {
                image1.Source = new BitmapImage(new Uri(filePath));
                ikonica.Text = filePath;
            }
        }

        //uklanjanje etikete
        private void ukloni_Click(object sender, RoutedEventArgs e)
        {
            etiketaTxt.Text = "Nijedna";
            comboEtikete.Text = "Odaberite...";
        }

        #region GotFocus

        private void oznaka_GotFocus(object sender, RoutedEventArgs e)
        {
            if(oznakaTxt.Text == "Unesite oznaku...")
                oznakaTxt.Text = "";
        }

        private void naziv_GotFocus(object sender, RoutedEventArgs e)
        {
            if(nazivTxt.Text == "Unesite naziv...")
                nazivTxt.Text = "";
        }

        private void opis_GotFocus(object sender, RoutedEventArgs e)
        {   
            if(opisTxt.Text == "Unesite opis...")
                opisTxt.Text = "";
        }

        private void drzava_GotFocus(object sender, RoutedEventArgs e)
        {
            if(drzavaTxt.Text == "Unesite državu...")
                drzavaTxt.Text = "";
        }

        private void grad_GotFocus(object sender, RoutedEventArgs e)
        {
            if(gradTxt.Text == "Unesite grad...")
                gradTxt.Text = "";
        }

        private void troskovi_GotFocus(object sender, RoutedEventArgs e)
        {
            if(troskoviTxt.Text == "Unesite troškove...")
                troskoviTxt.Text = "";
        }
        #endregion

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            oznakaTxt.Text = "Unesite oznaku...";
            nazivTxt.Text = "Unesite naziv...";
            comboBox1_Copy2.SelectedIndex = 0;
            opisTxt.Text = "Unesite opis...";
            drzavaTxt.Text = "Unesite državu...";
            gradTxt.Text = "Unesite grad...";
            troskoviTxt.Text = "Unesite troškove...";
            ikonica.Text = "Podrazumevana...";
            //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
            image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
            datum.Text = "";
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            comboTip.Text = "Odaberite...";
            comboEtikete.Text = "Odaberite...";
            etiketaTxt.Text = "Nijedna";
            istOdrz.ItemsSource = null;
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            bool dodato = true;
            string oznakaDog = oznakaTxt.Text;
            string nazivDog = nazivTxt.Text;
            string opisDog = opisTxt.Text;
            string drzavaDog = drzavaTxt.Text;
            string gradDog = gradTxt.Text;
            string troskoviDog = troskoviTxt.Text;
            string tipDog = comboTip.Text;
            //string etiketaDog = comboEtikete.Text;
            string etiketaDog = etiketaTxt.Text;
            string posecenostDog = comboBox1_Copy2.Text;
            string humKar = "";

            if (radioButton1.IsChecked == true)
            {
                humKar = "Da";
            }else if (radioButton2.IsChecked == true)
            {
                humKar = "Ne";
            }

            string ikonaDog = ikonica.Text;
            string datDog = datum.Text;

            //provera da li dogadjaj postoji vec pod unetom oznakom
            for(int i = 0; i < listaDogadjaja.Count(); i++)
            {
                if (listaDogadjaja.ElementAt(i).oznaka.Equals(oznakaDog))
                {
                    MessageBox.Show("Događaj pod takvom oznakom već postoji!");
                    dodato = false;
                    break;
                }else
                {
                    dodato = true;
                }
            }

            if (comboTip.SelectedItem == null)
            {

            }

            //provera da li je oznaka broj
            int num = 0;
            int num2 = 0;
            string s = oznakaTxt.Text;
            string s2 = troskoviTxt.Text;
            bool result = int.TryParse(s, out num);
            bool result2 = int.TryParse(s2, out num2);

            //provera da li su uneti odgovarajuci podaci i da li su polja prazna
            if (oznakaTxt.Text !="Unesite oznaku..." && nazivTxt.Text != "Unesite naziv..." && comboTip.Text != "Odaberite..." && result && result2)
            {
                if(oznakaTxt.Text !="" && nazivTxt.Text != "" && comboTip.Text != "Odaberite...")
                {
                    if (dodato)
                    {   
                        //nema ikone
                        if (ikonaDog.Equals("Podrazumevana..."))
                        {
                            //ikonaDog = "C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png";
                            ikonaDog = "pack://application:,,,/noimg.png";
                        }
                        else
                        {
                            ikonica.Text = ikonaDog;
                        }

                        DateTime datum1 = RandomDay();
                        DateTime datum2 = RandomDay();
                        DateTime datum3 = RandomDay();
                        DateTime datum4 = RandomDay();
                        List<String> ist = new List<string>();

                        Random rnd = new Random();
                        int broj = rnd.Next(2, 5);

                        if(broj == 2)
                        {
                            ist.Add(datum1.ToString("MMM/dd/yyyy"));
                            ist.Add(datum2.ToString("MMM/dd/yyyy"));
                        }
                        else if(broj == 3)
                        {
                            ist.Add(datum1.ToString("MMM/dd/yyyy"));
                            ist.Add(datum2.ToString("MMM/dd/yyyy"));
                            ist.Add(datum3.ToString("MMM/dd/yyy"));
                        }
                        else if(broj == 4)
                        {
                            ist.Add(datum1.ToString("MMM/dd/yyyy"));
                            ist.Add(datum2.ToString("MMM/dd/yyyy"));
                            ist.Add(datum3.ToString("MMM/dd/yyyy"));
                            ist.Add(datum4.ToString("MMM/dd/yyyy"));
                        }

                        //instanciranje novog dogadjaja
                        Dogadjaj d = new Dogadjaj(oznakaDog, nazivDog, opisDog, tipDog, etiketaDog, posecenostDog, humKar, ikonaDog, troskoviDog, drzavaDog, gradDog, datDog, ist);
                        listaDogadjaja.Add(d);
                        MainWindow.listaDog.Add(d);

                        MessageBox.Show("Uspešno ste napravili događaj!");
                        //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
                        image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));

                        FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listaDogadjaja);

                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = listaDogadjaja;
                        dataGrid.Columns[0].Header = "Oznaka";
                        dataGrid.Columns[1].Header = "Naziv";
                        dataGrid.Columns[2].Header = "Opis";
                        dataGrid.Columns[3].Header = "Država";
                        dataGrid.Columns[4].Header = "Grad";
                        dataGrid.Columns[5].Header = "Troškovi održavanja";
                        dataGrid.Columns[6].Header = "Tip";
                        dataGrid.Columns[7].Header = "Etiketa";
                        dataGrid.Columns[8].Header = "Posećenost";
                        dataGrid.Columns[9].Header = "Humanitarnog karaktera";
                        dataGrid.Columns[10].Header = "Ikonica";
                        dataGrid.Columns[11].Header = "Datum održavanja";
                        dataGrid.Columns[12].Header = "Istorija održavanja";
                        clearAll();
                        stream.Close();
                    }
                }else
                {
                    MessageBox.Show("Odgovarajuća polja ne smeju biti prazna!");
                }
            }else
            {
                MessageBox.Show("Molimo Vas unesite odgovarajuće vrednosti!");
            }
        }

        private void obrisi_Click(object sender, RoutedEventArgs e)
        {
            string oznakaDog = oznakaTxt.Text;
            for(int i = 0; i < listaDogadjaja.Count(); i++)
            {
                if (listaDogadjaja.ElementAt(i).oznaka.Equals(oznakaDog))
                {
                    listaDogadjaja.RemoveAt(i);
                    MainWindow.listaDog.RemoveAt(i);
                    MessageBox.Show("Uspešno ste obrisali događaj!");
                    break;
                }
            }

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaDogadjaja;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Naziv";
            dataGrid.Columns[2].Header = "Opis";
            dataGrid.Columns[3].Header = "Država";
            dataGrid.Columns[4].Header = "Grad";
            dataGrid.Columns[5].Header = "Troškovi održavanja";
            dataGrid.Columns[6].Header = "Tip";
            dataGrid.Columns[7].Header = "Etiketa";
            dataGrid.Columns[8].Header = "Posećenost";
            dataGrid.Columns[9].Header = "Humanitarnog karaktera";
            dataGrid.Columns[10].Header = "Ikonica";
            dataGrid.Columns[11].Header = "Datum održavanja";
            dataGrid.Columns[12].Header = "Istorija održavanja";

            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaDogadjaja);
            clearAll();
            stream.Close();
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            string oznakaDog = oznakaTxt.Text;
            string nazivDog = nazivTxt.Text;
            string opisDog = opisTxt.Text;
            string drzavaDog = drzavaTxt.Text;
            string gradDog = gradTxt.Text;
            string troskoviDog = troskoviTxt.Text;
            string tipDog = comboTip.Text;
            //string etiketaDog = comboEtikete.Text;
            string etiketaDog = etiketaTxt.Text;
            string posecenostDog = comboBox1_Copy2.Text;
            string humKar = "";

            if (radioButton1.IsChecked == true)
            {
                humKar = "Da";
            }
            else if (radioButton2.IsChecked == true)
            {
                humKar = "Ne";
            }

            string ikonaDog = ikonica.Text;
            string datDog = datum.Text;

            for (int i = 0; i < listaDogadjaja.Count(); i++)
            {
                if (listaDogadjaja.ElementAt(i).oznaka.Equals(oznakaDog))
                {
                    listaDogadjaja.ElementAt(i).naziv = nazivDog;
                    listaDogadjaja.ElementAt(i).opis = opisDog;
                    listaDogadjaja.ElementAt(i).drzava = drzavaDog;
                    listaDogadjaja.ElementAt(i).grad = gradDog;
                    listaDogadjaja.ElementAt(i).troskovi_odrzavanja = troskoviDog;
                    listaDogadjaja.ElementAt(i).tip = tipDog;
                    listaDogadjaja.ElementAt(i).etiketa = etiketaDog;
                    listaDogadjaja.ElementAt(i).posecenost_dogadjaja = posecenostDog;

                    if (radioButton1.IsChecked == true)
                    {
                        listaDogadjaja.ElementAt(i).humanitarnog_karaktera = "Da";
                    }
                    else if (radioButton2.IsChecked == true)
                    {
                        listaDogadjaja.ElementAt(i).humanitarnog_karaktera = "Ne";
                    }

                    if(ikonaDog == "Podrazumevana...")
                    {
                        listaDogadjaja.ElementAt(i).ikonica = listaDogadjaja.ElementAt(i).ikonica;
                    }
                    else
                    {
                        listaDogadjaja.ElementAt(i).ikonica = ikonaDog;
                    }

                    listaDogadjaja.ElementAt(i).datum_odrzavanja = datDog;

                    MessageBox.Show("Uspešno ste sačuvali izmene!");
                    //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
                    image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
                }
            }

            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaDogadjaja);

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaDogadjaja;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Naziv";
            dataGrid.Columns[2].Header = "Opis";
            dataGrid.Columns[3].Header = "Država";
            dataGrid.Columns[4].Header = "Grad";
            dataGrid.Columns[5].Header = "Troškovi održavanja";
            dataGrid.Columns[6].Header = "Tip";
            dataGrid.Columns[7].Header = "Etiketa";
            dataGrid.Columns[8].Header = "Posećenost";
            dataGrid.Columns[9].Header = "Humanitarnog karaktera";
            dataGrid.Columns[10].Header = "Ikonica";
            dataGrid.Columns[11].Header = "Datum održavanja";
            clearAll();
            stream.Close();
        }

        //u zavisnosti od selektovane vrednosti comboboxa stavi ikonicu
        private void tip_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TipDogadjaja selektovan = (TipDogadjaja)cb.SelectedItem;

            if(selektovan == null)
            {
                return;
            }

            Dogadjaj d = new Dogadjaj();
            d.ikonica = selektovan.ikonica;

            string path = d.ikonica;
            image1.Source = new BitmapImage(new Uri(path));
            ikonica.Text = path;
        }

        private void data_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                var row = (Dogadjaj)dataGrid.SelectedItem;
                oznakaTxt.Text = row.oznaka;
                nazivTxt.Text = row.naziv;
                opisTxt.Text = row.opis;
                drzavaTxt.Text = row.drzava;
                gradTxt.Text = row.grad;
                troskoviTxt.Text = row.troskovi_odrzavanja;
                comboTip.Text = row.tip;
                //comboEtikete.Text = row.etiketa;
                etiketaTxt.Text = row.etiketa;
                comboBox1_Copy2.Text = row.posecenost_dogadjaja;
                datum.Text = row.datum_odrzavanja;
                ikonica.Text = row.ikonica;
                image1.Source = new BitmapImage(new Uri(ikonica.Text));
                istOdrz.ItemsSource = row.istorija_odrzavanja;

                if (row.humanitarnog_karaktera == "Da")
                {
                    radioButton1.IsChecked = true;
                }else if (row.humanitarnog_karaktera == "Ne")
                {
                    radioButton2.IsChecked = true;
                }
            }
        }

        //odabir jedne ili vise etiketa za nas dogadjaj
        private void etiketa_DropDownClosed(object sender, EventArgs e)
        {
            //podelimo tekst u textBoxu etiketa po razmacima
            string etiketa = etiketaTxt.Text;
            string[] etikete = etiketa.Split(' ');
            bool postoji = false;

            //iteriramo kroz niz etiketa i proveravamo da li ona koju dodajemo postoji
            foreach(string et in etikete)
            {
                if (comboEtikete.Text.Equals(et))
                {
                    postoji = true;
                    break;
                }
                else if (comboEtikete.Text.Equals("Odaberite..."))
                {
                    postoji = true;
                    break;
                }
                else
                {
                    postoji = false;
                }
            }

            //ukoliko ne postoji etiketa, dodamo je
            if (!postoji)
            {
                if (etiketaTxt.Text.Equals("Nijedna"))
                {
                    etiketaTxt.Text = "";
                }
                
                etiketaTxt.Text += comboEtikete.Text + " ";
            }

            comboEtikete.Text = "Odaberite...";            
        }

        private void clearAll()
        {
            oznakaTxt.Text = "Unesite oznaku...";
            nazivTxt.Text = "Unesite naziv...";
            comboBox1_Copy2.SelectedIndex = 0;
            opisTxt.Text = "Unesite opis...";
            drzavaTxt.Text = "Unesite državu...";
            gradTxt.Text = "Unesite grad...";
            troskoviTxt.Text = "Unesite troškove...";
            ikonica.Text = "Podrazumevana...";
            //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
            image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
            datum.Text = "";
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            comboTip.Text = "Odaberite...";
            comboEtikete.Text = "Odaberite...";
            etiketaTxt.Text = "Nijedna";
            istOdrz.ItemsSource = null;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);

            focusedControl = this;

            string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
            HelpProvider.ShowHelp(str, this);

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);

            focusedControl = this;

            string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
            HelpProvider.ShowHelp(str, this);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaDogadjaja);
            stream.Close();
        }

        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
