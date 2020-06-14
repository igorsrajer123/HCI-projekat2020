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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HCI_projekat_2020
{
    /// <summary>
    /// Interaction logic for PretraziEntitete.xaml
    /// </summary>
    public partial class PretraziEntitete : Window
    {
        public static ObservableCollection<Dogadjaj> listaDog = new ObservableCollection<Dogadjaj>();

        public static ObservableCollection<TipDogadjaja> listaTip = new ObservableCollection<TipDogadjaja>();

        public static ObservableCollection<EtiketaDogadjaja> listaEt = new ObservableCollection<EtiketaDogadjaja>();

        public PretraziEntitete()
        {
            foreach (Dogadjaj dog in DodajDogadjaj.listaDogadjaja)
            {
                listaDog.Add(dog);
            }

            foreach (TipDogadjaja tip in DodajTip.listaTipova)
            {
                listaTip.Add(tip);
            }

            foreach (EtiketaDogadjaja et in DodajEtiketu.listaEtiketa)
            {
                listaEt.Add(et);
            }

            InitializeComponent();

            #region Ucitavanje
            //ucitavanje dogadjaja
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            long length = new System.IO.FileInfo(".//.//data1.bin").Length;
            if (length > 0)
                listaDog = (ObservableCollection<Dogadjaj>)bin.Deserialize(stream);
            if (listaDog.Count() != 0)
            {
                listView1.ItemsSource = null;
                listView1.ItemsSource = listaDog;
            }
            stream.Close();

            //ucitavanje tipova
            FileStream stream1 = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin1 = new BinaryFormatter();

            long length1 = new System.IO.FileInfo(".//.//data.bin").Length;
            if (length1 > 0)
                listaTip = (ObservableCollection<TipDogadjaja>)bin1.Deserialize(stream1);
            if (listaTip.Count() != 0)
            {
                listView2.ItemsSource = null;
                listView2.ItemsSource = listaTip;
            }
            stream1.Close();

            //ucitavanje etiketa
            FileStream stream2 = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin2 = new BinaryFormatter();

            long length2 = new System.IO.FileInfo(".//.//data2.bin").Length;
            if (length2 > 0)
                listaEt = (ObservableCollection<EtiketaDogadjaja>)bin2.Deserialize(stream2);
            if (listaEt.Count() != 0)
            {
                listView3.ItemsSource = null;
                listView3.ItemsSource = listaEt;
            }
            stream2.Close();

            #endregion
        }

        #region PonistiPretragu
        private void ponisti1_Click(object sender, RoutedEventArgs e)
        {           
            nazDog.Text = "Pretraga po nazivu...";
            oznDog.Text = "Pretraga po oznaci...";
            tipDog.Text = "Pretraga po tipu...";
            listView1.ItemsSource = listaDog;

            uklNazDog.IsEnabled = false;
            uklNazDog.Background = Brushes.LightGray;
        }

        private void ponisti11_Click(object sender, RoutedEventArgs e)
        {           
            nazTip.Text = "Pretraga po nazivu...";
            oznTip.Text = "Pretraga po oznaci...";
               
            listView2.ItemsSource = listaTip;
          
            uklNazTip.IsEnabled = false;
            uklNazTip.Background = Brushes.LightGray;
        }

        private void uklOznEt_Click(object sender, RoutedEventArgs e)
        {
            
            if (!oznEt.Text.Equals("Pretraga po oznaci..."))
            {
                oznEt.Text = "Pretraga po oznaci...";
                listView3.ItemsSource = listaEt;
            }

           uklOznEt.IsEnabled = false;
           uklOznEt.Background = Brushes.LightGray;
        }

        #endregion

        #region GotFocus
        private void nazDog_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po nazivu..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus += nazDog_GotFocus;

            uklNazDog.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklNazDog.Background = img;
        }

        private void oznDog_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po oznaci..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus += oznDog_GotFocus;

            uklNazDog.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklNazDog.Background = img;
        }

        private void tipDog_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po tipu..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus += tipDog_GotFocus;

            uklNazDog.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklNazDog.Background = img;
        }

        private void nazTip_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po nazivu..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus += nazTip_GotFocus;

            uklNazTip.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklNazTip.Background = img;
        }

        private void oznTip_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po oznaci..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus += oznTip_GotFocus;

            uklNazTip.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklNazTip.Background = img;
        }

        private void oznEt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga po oznaci..."))
            {
                tb.Text = string.Empty;
            }

            tb.GotFocus += oznEt_GotFocus;

            uklOznEt.IsEnabled = true;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            uklOznEt.Background = img;
        }

        #endregion

        #region LostFocus

        private void nazDog_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po nazivu...";
            }

            if (!oznDog.IsFocused && !tipDog.IsFocused)
            {
                uklNazDog.IsEnabled = false;
                uklNazDog.Background = Brushes.LightGray;
            }

            tb.GotFocus += nazDog_GotFocus;
        }

        private void oznDog_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po oznaci...";
            }

            if (!nazDog.IsFocused && !tipDog.IsFocused)
            {
                uklNazDog.IsEnabled = false;
                uklNazDog.Background = Brushes.LightGray;
            }

            tb.GotFocus += oznDog_GotFocus;
        }

        private void tipDog_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po tipu...";
            }

            if (!oznDog.IsFocused && !nazDog.IsFocused)
            {
                uklNazDog.IsEnabled = false;
                uklNazDog.Background = Brushes.LightGray;
            }

            tb.GotFocus += tipDog_GotFocus;
        }

        private void nazTip_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po nazivu...";
            }

            if (!oznTip.IsFocused)
            {
                uklNazTip.IsEnabled = false;
                uklNazTip.Background = Brushes.LightGray;
            }

            tb.GotFocus += nazTip_GotFocus;
        }

        private void oznTip_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po oznaci...";
            }

            if (!nazTip.IsFocused)
            {
                uklNazTip.IsEnabled = false;
                uklNazTip.Background = Brushes.LightGray;
            }

            tb.GotFocus += oznTip_GotFocus;
        }

        private void oznEt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga po oznaci...";
            }

            tb.GotFocus += oznEt_GotFocus;
            uklOznEt.IsEnabled = false;
            uklOznEt.Background = Brushes.LightGray;
        }
        #endregion

        #region TextChanged

        private void nazDog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!nazDog.Text.Equals("Pretraga po nazivu..."))
            {
                var ls2 = listView1.ItemsSource.Cast<Dogadjaj>();
                var dogadjaji2 = (from d2 in ls2 where d2.naziv.Contains(nazDog.Text) select d2);
                listView1.ItemsSource = dogadjaji2;
                listView1.InvalidateVisual();

                if (oznDog.Text.Equals("") && nazDog.Text.Equals("") && tipDog.Text.Equals(""))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (oznDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...") && tipDog.Text.Equals("Pretraga po tipu...")))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (nazDog.Text.Equals("") && ( tipDog.Text.Equals("Pretraga po tipu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (tipDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
            }
        }

        private void oznDog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!oznDog.Text.Equals("Pretraga po oznaci..."))
            {
                var ls2 = listView1.ItemsSource.Cast<Dogadjaj>();
                var dogadjaji2 = (from d2 in ls2 where d2.oznaka.Contains(oznDog.Text) select d2);
                listView1.ItemsSource = dogadjaji2;
                listView1.InvalidateVisual();

                if (oznDog.Text.Equals("") && nazDog.Text.Equals("") && tipDog.Text.Equals(""))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (oznDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...") && tipDog.Text.Equals("Pretraga po tipu...")))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (nazDog.Text.Equals("") && (tipDog.Text.Equals("Pretraga po tipu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (tipDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
            }
        }

        private void tipDog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tipDog.Text.Equals("Pretraga po tipu..."))
            {
                var ls2 = listView1.ItemsSource.Cast<Dogadjaj>();
                var dogadjaji2 = (from d2 in ls2 where d2.tip.Contains(tipDog.Text) select d2);
                listView1.ItemsSource = dogadjaji2;
                listView1.InvalidateVisual();

                if (oznDog.Text.Equals("") && nazDog.Text.Equals("") && tipDog.Text.Equals(""))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (oznDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...") && tipDog.Text.Equals("Pretraga po tipu...")))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (nazDog.Text.Equals("") && (tipDog.Text.Equals("Pretraga po tipu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
                else if (tipDog.Text.Equals("") && (nazDog.Text.Equals("Pretraga po nazivu...")) && oznDog.Text.Equals("Pretraga po oznaci..."))
                {
                    listView1.ItemsSource = listaDog;
                }
            }
        }

        private void oznEt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!oznEt.Text.Equals("Pretraga po oznaci..."))
            {
                var ls2 = listView3.ItemsSource.Cast<EtiketaDogadjaja>();
                var etikete2 = (from d2 in ls2 where d2.oznaka.Contains(oznEt.Text) select d2);
                listView3.ItemsSource = etikete2;
            }
        }

        private void oznTip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!oznTip.Text.Equals("Pretraga po oznaci..."))
            {
                var ls2 = listView2.ItemsSource.Cast<TipDogadjaja>();
                var tipovi2 = (from d2 in ls2 where d2.oznaka.Contains(oznTip.Text) select d2);
                listView2.ItemsSource = tipovi2;

                if(oznTip.Text.Equals("") && nazTip.Text.Equals(""))
                {
                    listView2.ItemsSource = listaTip;
                }
                else if (oznTip.Text.Equals("") && nazTip.Text.Equals("Pretraga po nazivu..."))
                {
                    listView2.ItemsSource = listaTip;
                }
                else if (oznTip.Text.Equals("Pretraga po oznaci...") && nazTip.Text.Equals(""))
                {
                    listView2.ItemsSource = listaTip;
                }
            }
        }

        private void nazTip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!nazTip.Text.Equals("Pretraga po nazivu..."))
            {
                var ls2 = listView2.ItemsSource.Cast<TipDogadjaja>();
                var tipovi2 = (from d2 in ls2 where d2.naziv.Contains(nazTip.Text) select d2);
                listView2.ItemsSource = tipovi2;

                if (oznTip.Text.Equals("") && nazTip.Text.Equals(""))
                {
                    listView2.ItemsSource = listaTip;
                }
                else if (oznTip.Text.Equals("") && nazTip.Text.Equals("Pretraga po nazivu..."))
                {
                    listView2.ItemsSource = listaTip;
                }
                else if (oznTip.Text.Equals("Pretraga po oznaci...") && nazTip.Text.Equals(""))
                {
                    listView2.ItemsSource = listaTip;
                }
            }
        }

        #endregion
    }
}
