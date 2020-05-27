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
    /// Interaction logic for UkloniEntitet.xaml
    /// </summary>
    public partial class UkloniEntitet : Window
    {
        public static ObservableCollection<Dogadjaj> listaDog = new ObservableCollection<Dogadjaj>();

        public static ObservableCollection<TipDogadjaja> listaTip = new ObservableCollection<TipDogadjaja>();

        public static ObservableCollection<EtiketaDogadjaja> listaEt = new ObservableCollection<EtiketaDogadjaja>();

        public UkloniEntitet()
        {
            foreach (Dogadjaj dog in DodajDogadjaj.listaDogadjaja)
            {
                listaDog.Add(dog);
            }

            foreach(TipDogadjaja tip in DodajTip.listaTipova)
            {
                listaTip.Add(tip);
            }

            foreach(EtiketaDogadjaja et in DodajEtiketu.listaEtiketa)
            {
                listaEt.Add(et);
            }

            InitializeComponent();
            this.DataContext = DodajDogadjaj.listaDogadjaja;

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
                listaEt= (ObservableCollection<EtiketaDogadjaja>)bin2.Deserialize(stream2);
            if (listaEt.Count() != 0)
            {
                listView3.ItemsSource = null;
                listView3.ItemsSource = listaEt;
            }
            stream2.Close();


        }

        private void ukloni_Click(object sender, RoutedEventArgs e)
        {
            if (tab1.IsSelected)
            {
                Dogadjaj d = (Dogadjaj)listView1.SelectedItem;
                for (int i = 0; i < listaDog.Count; i++)
                {
                    if (listaDog.ElementAt(i).Equals(d))
                    {
                        listaDog.RemoveAt(i);
                        MainWindow.listaDog.RemoveAt(i);
                        break;
                    }
                }

                FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaDog);
                stream.Close();
            }
            else if (tab2.IsSelected)
            {
                TipDogadjaja t = (TipDogadjaja)listView2.SelectedItem;
                listaTip.Remove(t);

                FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaTip);
                stream.Close();
            }
            else if (tab3.IsSelected)
            {
                EtiketaDogadjaja et = (EtiketaDogadjaja)listView3.SelectedItem;
                listaEt.Remove(et);

                FileStream stream = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaEt);
                stream.Close();
            }
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab1.IsSelected)
            {
                button.Content = "Ukloni događaj";
                if(listView1.SelectedItem == null)
                {
                    listView1.SelectedItem = ((ObservableCollection<Dogadjaj>)listView1.ItemsSource).FirstOrDefault();
                }
            }
            else if (tab2.IsSelected)
            {
                button.Content = "Ukloni tip";
                if(listView2.SelectedItem == null)
                {
                    listView2.SelectedItem = ((ObservableCollection<TipDogadjaja>)listView2.ItemsSource).FirstOrDefault();
                }
            }
            else if (tab3.IsSelected)
            {
                button.Content = "Ukloni etiketu";
                if(listView3.SelectedItem == null)
                {
                    listView3.SelectedItem = ((ObservableCollection<EtiketaDogadjaja>)listView3.ItemsSource).FirstOrDefault();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaDog);
            stream.Close();

            FileStream stream1 = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin1 = new BinaryFormatter();
            bin.Serialize(stream1, listaTip);
            stream1.Close();

            FileStream stream2 = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin2 = new BinaryFormatter();
            bin.Serialize(stream2, listaEt);
            stream2.Close();
        }

    }
}
