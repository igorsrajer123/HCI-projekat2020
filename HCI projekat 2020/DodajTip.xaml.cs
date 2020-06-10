using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Shapes;
using HCI_projekat_2020.Help;

namespace HCI_projekat_2020
{
    public struct tip
    {
        public string oznaka { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
    }

    /// <summary>
    /// Interaction logic for DodajTip.xaml
    /// </summary>
    public partial class DodajTip : Window
    {
        public tip ret1()
        {
            tip tp = new tip();
            tp.naziv = "Unesite naziv...";
            tp.oznaka = "Unesite oznaku...";
            tp.opis = "Unesite opis...";

            return tp;
        }

        public static string filePath;
        static public ObservableCollection<TipDogadjaja> listaTipova = new ObservableCollection<TipDogadjaja>();

        public DodajTip()
        {
            InitializeComponent();
            //this.DataContext = this;
            DataContext = ret1();

            //citanje iz binarne datoteke
            FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            long length = new System.IO.FileInfo(".//.//data.bin").Length;
            if(length > 0)
                listaTipova = (ObservableCollection<TipDogadjaja>)bin.Deserialize(stream);
            if(listaTipova.Count() != 0)
            {
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = listaTipova;
            }
            stream.Close();
        }

        //postavljanje ikonice
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();
            filePath = dlg.FileName;

            if(result == true)
            {
                image1.Source = new BitmapImage(new Uri(filePath));
                textBox1_Copy.Text = filePath;
            }
        }

        //klik na dugme "Odustani", resetovanje polja
        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Unesite oznaku...";
            textBox3.Text = "Unesite naziv...";
            textBox2.Text = "Unesite opis...";
            textBox1_Copy.Text = "Podrazumevana...";
            //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
            image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            bool dodato = true;
            string oznakaTipa = textBox1.Text;
            string nazivTipa = textBox3.Text;
            string opisTipa = textBox2.Text;
            string ikonaTipa = textBox1_Copy.Text;

            //prolazak kroz listu tipova i provera da li vec postoji tip sa oznakom koju pokusavamo da unesemo
            for(int i = 0; i < listaTipova.Count(); i++)
            {
                if (listaTipova.ElementAt(i).oznaka.Equals(oznakaTipa))
                {
                    MessageBox.Show("Oznaka tipa događaja koju ste uneli već postoji!");
                    dodato = false;
                    break;
                }
                else
                {
                    dodato = true;
                }
            }

            //provera da li je oznaka broj
            int num = 0;
            string s = textBox1.Text;
            bool result = int.TryParse(s, out num);


            if (textBox1.Text != "Unesite oznaku..." && textBox3.Text !="Unesite naziv..." && textBox2.Text !="Unesite opis..." && result)
            {
                if(textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
                {
                    if (dodato)
                    {
                        if (ikonaTipa.Equals("Podrazumevana..."))
                        {
                            //ikonaTipa = "C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png";
                            ikonaTipa = "pack://application:,,,/noimg.png";
                        }
                        else
                        {
                            textBox1_Copy.Text = ikonaTipa;
                        }

                        TipDogadjaja t = new TipDogadjaja(oznakaTipa, nazivTipa, opisTipa, ikonaTipa);
                        listaTipova.Add(t);

                        MessageBox.Show("Uspešno ste napravili tip događaja!");
                        //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
                        image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));

                        FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listaTipova);

                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = listaTipova;
                        dataGrid.Columns[0].Header = "Oznaka";
                        dataGrid.Columns[1].Header = "Naziv";
                        dataGrid.Columns[2].Header = "Opis";
                        dataGrid.Columns[3].Header = "Ikonica";
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
            string oznakaTipa = textBox1.Text;
            for(int i = 0; i < listaTipova.Count(); i++)
            {
                if (listaTipova.ElementAt(i).oznaka.Equals(oznakaTipa))
                {
                    listaTipova.RemoveAt(i);
                    MessageBox.Show("Uspešno ste obrisali tip događaja!");
                    break;
                }             
            }

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaTipova;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Naziv";
            dataGrid.Columns[2].Header = "Opis";
            dataGrid.Columns[3].Header = "Ikona";

            FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaTipova);
            clearAll();
            stream.Close();
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            string oznakaTip = textBox1.Text;
            string nazivTip = textBox3.Text;
            string opisTip = textBox2.Text;
            string ikonaTip = textBox1_Copy.Text;

            for(int i = 0; i < listaTipova.Count(); i++)
            {
                if (listaTipova.ElementAt(i).oznaka.Equals(oznakaTip))
                {
                    listaTipova.ElementAt(i).naziv = nazivTip;
                    listaTipova.ElementAt(i).opis = opisTip;

                    if (ikonaTip == "Podrazumevana...")
                    {
                        listaTipova.ElementAt(i).ikonica = listaTipova.ElementAt(i).ikonica;
                    }else
                    {
                        listaTipova.ElementAt(i).ikonica = ikonaTip;
                    }

                    MessageBox.Show("Uspešno ste sačuvali izmene!");
                    // image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
                    image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
                }
            }

            FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaTipova);

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaTipova;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Naziv";
            dataGrid.Columns[2].Header = "Opis";
            dataGrid.Columns[3].Header = "Ikonica";
            clearAll();
            stream.Close();
        }
       
        #region GotFocus
        public void oznaka_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "Unesite oznaku...")
            {
                textBox1.Text = "";
            }
        }

        public void naziv_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBox3.Text == "Unesite naziv...")
            {
                textBox3.Text = "";
            }
        }

        public void opis_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBox2.Text == "Unesite opis...")
            {
                textBox2.Text = "";
            }
        }
        #endregion

        //u zavisnosti od selektovanog reda u datagrid-u popunjava polja
        private void data_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                var row = (TipDogadjaja)dataGrid.SelectedItem;
                textBox1.Text = row.oznaka;
                textBox3.Text = row.naziv;
                textBox2.Text = row.opis;
                textBox1_Copy.Text = row.ikonica;
                image1.Source = new BitmapImage(new Uri(textBox1_Copy.Text));
            }
        }

        //ciscenje teksta 
        private void clearAll()
        {
            textBox1.Text = "Unesite oznaku...";
            textBox3.Text = "Unesite naziv...";
            textBox2.Text = "Unesite opis...";
            textBox1_Copy.Text = "Podrazumevana...";
            //image1.Source = new BitmapImage(new Uri("C:\\Users\\asd\\Desktop\\HCI projekat 2020\\HCI projekat 2020\\noimg.png"));
            image1.Source = new BitmapImage(new Uri("pack://application:,,,/noimg.png"));
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

        //prilikom gasenja prozora, serijalizacija u bin obliku
        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaTipova);
            stream.Close();
        }
    }
}
