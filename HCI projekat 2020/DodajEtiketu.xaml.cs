using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Runtime.Serialization.Formatters.Binary;
using Dijalog = System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Text.RegularExpressions;


namespace HCI_projekat_2020
{
    public struct etiketa
    {
        public string oznaka { get; set; }
        public string opis { get; set; }
    }

    /// <summary>
    /// Interaction logic for DodajEtiketu.xaml
    /// </summary>
    public partial class DodajEtiketu : Window
    {
        public static etiketa ret2()
        {
            etiketa et = new etiketa();
            et.oznaka = "Unesite oznaku...";
            et.opis = "Unesite opis...";

            return et;
        }

        public static ObservableCollection<EtiketaDogadjaja> listaEtiketa = new ObservableCollection<EtiketaDogadjaja>();

        public DodajEtiketu()
        {
            InitializeComponent();
            DataContext = ret2();

            //ucitavanje liste etiketa iz binarne datoteke
            FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();
            
            long length = new System.IO.FileInfo(".//.//data2.bin").Length;
            if (length > 0)
                listaEtiketa = (ObservableCollection<EtiketaDogadjaja>)bin.Deserialize(stream);
            if (listaEtiketa.Count() != 0)
            {
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = listaEtiketa;
            }         
            stream.Close();
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Unesite oznaku...";
            textBox2.Text = "Unesite opis...";
            Color clr = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(clr);
            grid1.Background = brush;
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            bool dodato = true;
            string oznakaEtiketa = textBox1.Text;
            string nazivEtiketa = textBox2.Text;
            Color clr = ((SolidColorBrush)grid1.Background).Color;
            string bojaEtiketa = clr.ToString();

            for (int i = 0; i < listaEtiketa.Count(); i++)
            {
                if (listaEtiketa.ElementAt(i).oznaka.Equals(oznakaEtiketa))
                {
                    MessageBox.Show("Etiketa sa tom oznakom već postoji!");
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


            if (textBox1.Text != "Unesite oznaku..." && textBox2.Text != "Unesite opis..." && result)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (dodato)
                    {
                        EtiketaDogadjaja et = new EtiketaDogadjaja(oznakaEtiketa, bojaEtiketa, nazivEtiketa);
                        listaEtiketa.Add(et);

                        MessageBox.Show("Uspešno ste napravili etiketu događaja!");

                        FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listaEtiketa);

                        Color clr1 = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
                        SolidColorBrush brush = new SolidColorBrush(clr1);
                        grid1.Background = brush;

                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = listaEtiketa;
                        dataGrid.Columns[0].Header = "Oznaka";
                        dataGrid.Columns[1].Header = "Boja";
                        dataGrid.Columns[2].Header = "Opis";
                        clearAll();
                        stream.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Odgovarajuća polja ne smeju biti prazna!");
                }
            }
            else
            {
                MessageBox.Show("Molimo Vas unesite odgovarajuće vrednosti!");
            }
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            string oznakaEtiketa = textBox1.Text;
            string opisEtiketa = textBox2.Text;
            Color clr = ((SolidColorBrush)grid1.Background).Color;
            string bojaEtiketa = clr.ToString();


            for (int i = 0; i < listaEtiketa.Count(); i++)
            {
                if (listaEtiketa.ElementAt(i).oznaka.Equals(oznakaEtiketa))
                {
                    listaEtiketa.ElementAt(i).boja = bojaEtiketa;
                    listaEtiketa.ElementAt(i).opis = opisEtiketa;

                    MessageBox.Show("Uspešno ste sačuvali izmene!");
                }
            }

            FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaEtiketa);

            Color clr1 = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(clr1);
            grid1.Background = brush;

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaEtiketa;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Boja";
            dataGrid.Columns[2].Header = "Opis";
            clearAll();
            stream.Close();

        }

        private void obrisi_Click(object sender, RoutedEventArgs e)
        {
            string oznakaEtiketa = textBox1.Text;
            for(int i = 0; i < listaEtiketa.Count(); i++)
            {
                if (listaEtiketa.ElementAt(i).oznaka.Equals(oznakaEtiketa))
                {
                    listaEtiketa.RemoveAt(i);
                    MessageBox.Show("Uspešno ste obrisali etiketu događaja!");
                    break;
                }
            }

            Color clr1 = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(clr1);
            grid1.Background = brush;

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listaEtiketa;
            dataGrid.Columns[0].Header = "Oznaka";
            dataGrid.Columns[1].Header = "Boja";
            dataGrid.Columns[2].Header = "Opis";

            FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaEtiketa);
            clearAll();
            stream.Close();
        }

        private void boja_Click(object sender, RoutedEventArgs e)
        {
            Dijalog.ColorDialog dlg = new Dijalog.ColorDialog();

            if(dlg.ShowDialog() == Dijalog.DialogResult.OK)
            {
                Color clr = Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
                SolidColorBrush brush = new SolidColorBrush(clr);
                grid1.Background = brush;
            }
        }

        //u zavisnosti od selektovanog reda u datagrid-u popunjava polja
        private void data_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                var row = (EtiketaDogadjaja)dataGrid.SelectedItem;
                textBox1.Text = row.oznaka;
                textBox2.Text = row.opis;
                Color clr = (Color)ColorConverter.ConvertFromString(row.boja);
                SolidColorBrush brush = new SolidColorBrush(clr);
                grid1.Background = brush;
            }
        }

        //ciscenje teksta 
        private void clearAll()
        {
            textBox1.Text = "Unesite oznaku...";
            textBox2.Text = "Unesite opis...";
            Color clr1 = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(clr1);
            grid1.Background = brush;
        }

        #region GotFocus

        private void oznaka_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "Unesite oznaku...")
            {
                textBox1.Text = "";
            }
        }

        private void opis_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBox2.Text == "Unesite opis...")
            {
                textBox2.Text = "";
            }
        }
        #endregion

        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaEtiketa);
            stream.Close();
        }
    }
}
