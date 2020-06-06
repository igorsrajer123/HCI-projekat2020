using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace HCI_projekat_2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Dugme : Button
    {
       [System.ComponentModel.Browsable(false)]
        public System.Drawing.Rectangle Bounds { get; set; }

        public System.Drawing.Point Location { get; set; }

        public static readonly System.Drawing.Point Empty;

        public Dugme()
        {
        }
    }


    public partial class MainWindow : Window
    {
        private Dugme draggedItem;

        private bool dragging = false;

        private static bool initialized = false;

        public static ObservableCollection<Dogadjaj> listaDog = new ObservableCollection<Dogadjaj>();

        public static ObservableCollection<TipDogadjaja> listaTip = new ObservableCollection<TipDogadjaja>();

        public static ObservableCollection<EtiketaDogadjaja> listaEtiketa = new ObservableCollection<EtiketaDogadjaja>();

        public static  List<Dogadjaj> filterTip = new List<Dogadjaj>();
        public static List<Dogadjaj> filterEtiketa = new List<Dogadjaj>();
        public static List<Dogadjaj> filterHumKar = new List<Dogadjaj>();
        public static List<Dogadjaj> filterPosecenost = new List<Dogadjaj>();

        public MainWindow()
        {

            foreach (Dogadjaj dog in DodajDogadjaj.listaDogadjaja)
            {
                listaDog.Add(dog);
            }

            foreach(TipDogadjaja t in DodajTip.listaTipova)
            {
                listaTip.Add(t);
            }

            foreach(EtiketaDogadjaja e in DodajEtiketu.listaEtiketa)
            {
                listaEtiketa.Add(e);
            }

            InitializeComponent();
            this.DataContext = listaDog;

            #region UcitavanjeEntiteta

            //Serijalizacija dogadjaja
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            long length = new System.IO.FileInfo(".//.//data1.bin").Length;
            if (length > 0)
                listaDog = (ObservableCollection<Dogadjaj>)bin.Deserialize(stream);
            if (listaDog.Count() != 0)
            {
                listView.ItemsSource = null;
                listView.ItemsSource = listaDog;
            }
            stream.Close();

            //ucitavanje tipova
            FileStream stream2 = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin2 = new BinaryFormatter();

            long length2 = new System.IO.FileInfo(".//.//data.bin").Length;
            if (length2 > 0)
                listaTip = (ObservableCollection<TipDogadjaja>)bin2.Deserialize(stream2);
            if (listaTip.Count() != 0)
            {
               listViewTip.ItemsSource = null;
               listViewTip.ItemsSource = listaTip;
            }
            stream2.Close();

            //ucitavanje etiketa
            FileStream stream3 = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin3 = new BinaryFormatter();

            long length3 = new System.IO.FileInfo(".//.//data2.bin").Length;
            if (length3 > 0)
                listaEtiketa = (ObservableCollection<EtiketaDogadjaja>)bin3.Deserialize(stream3);
            if (listaEtiketa.Count() != 0)
            {
                listViewEtiketa.ItemsSource = null;
                listViewEtiketa.ItemsSource = listaEtiketa;
            }
            stream3.Close();
            #endregion

            listView.ItemContainerGenerator.ItemsChanged += listView_ItemUpdated;

            foreach (Dogadjaj d in listaDog)
            {
               canvasCreated(d);
            }

            textBlock.Text = DateTime.Now.ToString("dddd , MMM dd yyyy, hh:mm tt");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data5.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, listaDog);
            stream.Close();
        }

        #region Execute
        //===================================================================================
        private void Izadji_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Izadji_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //===================================================================================
        private void Dogadjaj_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Dogadjaj_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DodajDogadjaj dodaj = new DodajDogadjaj();
            dodaj.Show();
        }
        //===================================================================================
        private void Tip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DodajTip tip = new DodajTip();
            tip.Show();
        }
        //===================================================================================
        private void Etiketa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Etiketa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DodajEtiketu etiketa = new DodajEtiketu();
            etiketa.Show();
        }
        //===================================================================================
        private void UkloniEntitet_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UkloniEntitet_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UkloniEntitet ukloniEntitet = new UkloniEntitet();
            ukloniEntitet.Show();
        }

        private void pretraziEntitete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void pretraziEntitete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PretraziEntitete prE = new PretraziEntitete();
            prE.Show();
        }
        #endregion

        private void osvezi_Click(object sender, RoutedEventArgs e)
        {
            initialized = false; 

            foreach (Dogadjaj d in DodajDogadjaj.listaDogadjaja)
            {
                listaDog.Add(d);
            }

            Boolean isEmpty = !listaDog.Any();
            if (isEmpty)
            {
                listView.InvalidateVisual();
                listView.ItemsSource = null;
            }

            //listView.InvalidateVisual();
            FileStream stream = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            long length = new System.IO.FileInfo(".//.//data1.bin").Length;
            if (length > 0)
                listaDog = (ObservableCollection<Dogadjaj>)bin.Deserialize(stream);
            if (listaDog.Count() != 0)
            {
                listView.ItemsSource = null;
                listView.ItemsSource = listaDog;
            }
            stream.Close();

            canvas123.Children.Clear();

            foreach (Dogadjaj d in listaDog)
            {
                canvasCreated(d);
            }
        }

        private void listView_ItemUpdated(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            canvas123.Children.Clear();

            foreach (Dogadjaj d in listaDog)
            {
                canvasCreated(d);
            }
        }

        #region DragDrop

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);            
            if (draggedItem != null)
            {
                double maxX = canvas123.Width - 65;
                double maxY = canvas123.Height - 65;
                Point p = e.GetPosition(canvas123);

                if ((p.Y + 32.5 <= canvas123.Height && p.Y - 32.5 >= 0) && (p.X + 32.5 <= canvas123.Width && p.X - 32.5 >= 0))
                {
                    foreach (Dogadjaj d in listaDog)
                    {
                        if (d == draggedItem.Tag)
                        {
                            foreach (Dogadjaj d1 in listaDog)
                            { 
                                if (d1 != d)
                                {
                                    if (Math.Round(d1.X, 1) == Math.Round(d.X, 1) && Math.Round(d1.Y, 1) == Math.Round(d.Y, 1))
                                    {
                                        if (d.X == d1.X && d.Y == d1.Y)
                                        {
                                            d.X = d1.X + 25 / maxX;                                    
                                            break;
                                        }
                                        else if (d.X < d1.X && d.Y < d1.Y)
                                        {
                                                d.X = d1.X - 25 / maxX;
                                                d.Y = d1.Y - 25 / maxY;
                                                break;
                                        }
                                        else if (d.X > d1.X && d.Y < d1.Y)
                                        {
                                                d.X = d1.X + 25 / maxX;
                                                d.Y = d1.Y - 25 / maxY;
                                                break;
                                        }
                                        else if (d.X > d1.X && d.Y > d1.Y)
                                        {
                                                d.X = d1.X + 25 / maxX;
                                                d.Y = d1.Y + 25 / maxY;
                                                break;                      
                                        }
                                        else
                                        {
                                            d.X = d1.X - 25 / maxX;
                                            d.Y = d1.Y + 25 / maxY;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        d.X = (p.X - 32.5) / maxX;
                                        d.Y = (p.Y - 32.5) / maxY;
                                    }
                                }
                            }
                        }
                    }
                }

                canvas123.Children.Clear();
              
                foreach (Dogadjaj d in listaDog)
                {
                    canvasCreated(d);
                }

                draggedItem = null;
                dragging = false;
            }
            e.Handled = true;      
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.Move;
            double maxX = canvas123.Width - 65;
            double maxY = canvas123.Height - 65;
            Point p = e.GetPosition(canvas123);

            if ((p.Y + 32.5 <= canvas123.Height && p.Y - 32.5 >= 0) && (p.X + 32.5 <= canvas123.Width && p.X - 32.5 >= 0))
            {
                foreach (Dogadjaj d in listaDog)
                {
                    if (d == draggedItem.Tag)
                    {
                        d.X = (p.X - 32.5) / maxX;
                        d.Y = (p.Y - 32.5) / maxY;
                    }
                }
            }
            else
            {
                if (p.Y + 32.5 > canvas123.Height)
                {
                    ((Dogadjaj)draggedItem.Tag).Y = (canvas123.Height - 65) / maxY;
                }
                if (p.Y - 32.5 < 0)
                {
                    ((Dogadjaj)draggedItem.Tag).Y = 0 / maxY;
                }
                if (p.X + 32.5 > canvas123.Width)
                {
                    ((Dogadjaj)draggedItem.Tag).X = (canvas123.Width - 65) / maxX;
                }
                if (p.X - 32.5 < 0)
                {
                    ((Dogadjaj)draggedItem.Tag).X = 0 / maxX;
                }
                dragging = false;
            }

            canvas123.Children.Clear();

            foreach (Dogadjaj d in listaDog)
            {
                canvasCreated(d);
            }
            e.Handled = true;
        }

        private void canvasCreated(Dogadjaj d)
        {
            BitmapImage logo = new BitmapImage();
            Dugme dugme = new Dugme();
           
            dugme.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(button_selected);
            dugme.Width = 40;
            dugme.Height = 40;
            dugme.Focusable = false;
            dugme.Tag = d;
            dugme.ToolTip = "Oznaka: " + d.oznaka + ", Naziv: " + d.naziv;
            dugme.BorderBrush = Brushes.Black;
            dugme.BorderThickness = new Thickness(2);
         
            double maxX = canvas123.Width - dugme.Width;
            double maxY = canvas123.Height - dugme.Height;

            
            if(initialized == false)
            {
               for(int i = 1; i < listaDog.Count; i++)
                {
                    listaDog.ElementAt(i).Y = listaDog.ElementAt(i - 1).Y + 45 / maxY;
                }

                initialized = true;
            }

            foreach(Dogadjaj dog in listaDog)
            {
                if(dog.oznaka != d.oznaka && d.X == dog.X && d.Y == dog.Y)
                {
                    d.Y = dog.Y + 45 / maxY;
                    break;
                }
            }

            Canvas.SetLeft(dugme, d.X * maxX);
            Canvas.SetTop(dugme, d.Y * maxY);

            canvas123.Children.Add(dugme);

            try
            {
                logo.BeginInit();
                logo.UriSource = new Uri(d.ikonica);
                logo.CacheOption = BitmapCacheOption.OnLoad;
                logo.EndInit();
                ImageBrush img = new ImageBrush(logo);
                img.Stretch = Stretch.UniformToFill;              
                dugme.Background = img;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void button_selected(object sender, MouseButtonEventArgs e)
        { 
            if (!dragging)
            {
                dragging = true; 
                draggedItem = (Dugme)sender;
                DragDrop.DoDragDrop(this, draggedItem, DragDropEffects.Move);
                e.Handled = true;
            }
        }
        #endregion

        #region Search

        private void ponisti_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Equals("Pretraga..."))
            {
                textBox.Text = "Pretraga...";
                listView.ItemsSource = listaDog;
                listView.InvalidateVisual();
            }

            ponisti.IsEnabled = false;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals("Pretraga..."))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus -= textBox_GotFocus;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(string.Empty))
            {
                tb.Text = "Pretraga...";
                ponisti.IsEnabled = false;
            }
            tb.GotFocus += textBox_GotFocus;

            BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/lupa.png"));
            ImageBrush img = new ImageBrush(slika);
            img.Stretch = Stretch.Uniform;
            ponisti.Background = img;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!textBox.Text.Equals("Pretraga..."))
            {
                ponisti.IsEnabled = true;
                BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/x3.png"));
                ImageBrush img = new ImageBrush(slika);
                ponisti.Background = img;
                ponisti.ToolTip = "Poništi pretragu";

                var ls2 = listView.ItemsSource.Cast<Dogadjaj>();
                var dogadjaji2 = (from d2 in ls2 where d2.naziv.Contains(textBox.Text) select d2);
                listView.ItemsSource = dogadjaji2;
                listView.InvalidateVisual();                  
            }
        }
        #endregion

        #region Filters

        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            if(canvasFilters.Visibility == Visibility.Visible)
            {
                canvasFilters.Visibility = Visibility.Hidden;
                buttonDoFilter.IsEnabled = false;
                buttonDoFilter.Background = null;
            }
            else
            {
                canvasFilters.Visibility = Visibility.Visible;
                buttonDoFilter.IsEnabled = true;

                BitmapImage slika = new BitmapImage(new Uri("pack://application:,,,/filter.png"));
                ImageBrush img = new ImageBrush(slika);
                img.Stretch = Stretch.Uniform;
                buttonDoFilter.Background = img;
               buttonDoFilter.ToolTip = "Filtriraj";

                textBox.Text = "Pretraga...";
                listView.ItemsSource = listaDog;

                //ucitavanje tipova
                FileStream stream2 = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bin2 = new BinaryFormatter();

                long length2 = new System.IO.FileInfo(".//.//data.bin").Length;
                if (length2 > 0)
                    listaTip = (ObservableCollection<TipDogadjaja>)bin2.Deserialize(stream2);
                if (listaTip.Count() != 0)
                {
                    listViewTip.ItemsSource = null;
                    listViewTip.ItemsSource = listaTip;
                }
                stream2.Close();

                //ucitavanje etiketa
                FileStream stream3 = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bin3 = new BinaryFormatter();

                long length3 = new System.IO.FileInfo(".//.//data2.bin").Length;
                if (length3 > 0)
                    listaEtiketa = (ObservableCollection<EtiketaDogadjaja>)bin3.Deserialize(stream3);
                if (listaEtiketa.Count() != 0)
                {
                    listViewEtiketa.ItemsSource = null;
                    listViewEtiketa.ItemsSource = listaEtiketa;
                }
                stream3.Close();
            }
        }

        private void buttonDoFilter_Click(object sender, RoutedEventArgs e)
        {
            List<Dogadjaj> filterTip2 = new List<Dogadjaj>(filterTip);
            List<Dogadjaj> filterEtiketa2 = new List<Dogadjaj>(filterEtiketa);
            List<Dogadjaj> filterHumKar2 = new List<Dogadjaj>(filterHumKar);
            List<Dogadjaj> filterPosecenost2 = new List<Dogadjaj>(filterPosecenost);

            //logika filtriranja
            if(filterTip2.Any() && !filterEtiketa2.Any() && !filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                listView.ItemsSource = filterTip2;
            }
            else if (!filterTip2.Any() && !filterEtiketa2.Any() && !filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                listView.ItemsSource = listaDog;
            }
            else if (!filterTip2.Any() && filterEtiketa2.Any() && !filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                listView.ItemsSource = filterEtiketa2;
            }
            else if (!filterTip2.Any() && !filterEtiketa2.Any() && filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                listView.ItemsSource = filterHumKar2;
            }
            else if (!filterTip2.Any() && !filterEtiketa2.Any() && !filterHumKar2.Any() && filterPosecenost2.Any())
            {
                listView.ItemsSource = filterPosecenost2;
            }
            else if (filterTip2.Any() && filterEtiketa2.Any() && !filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                var d1 = filterTip2.Intersect<Dogadjaj>(filterEtiketa2);
                listView.ItemsSource = d1;
            }
            else if (filterTip2.Any() && !filterEtiketa2.Any() && filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                var d1 = filterTip2.Intersect<Dogadjaj>(filterHumKar2);
                listView.ItemsSource = d1;
            }
            else if (filterTip2.Any() && !filterEtiketa2.Any() && !filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterTip2.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d1;
            }
            else if (!filterTip2.Any() && filterEtiketa2.Any() && filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                var d1 =filterEtiketa2.Intersect<Dogadjaj>(filterHumKar2);
                listView.ItemsSource = d1;
            }
            else if (!filterTip2.Any() && filterEtiketa2.Any() && !filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterEtiketa2.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d1;
            }
            else if (!filterTip2.Any() && !filterEtiketa2.Any() && filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterHumKar2.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d1;
            }
            else if (filterTip2.Any() && filterEtiketa2.Any() && filterHumKar2.Any() && !filterPosecenost2.Any())
            {
                var d1 = filterEtiketa2.Intersect<Dogadjaj>(filterTip2);
                var d2 = d1.Intersect<Dogadjaj>(filterHumKar2);
                listView.ItemsSource = d2;
            }
            else if (filterTip2.Any() && filterEtiketa2.Any() && !filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterEtiketa2.Intersect<Dogadjaj>(filterTip2);
                var d2 = d1.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d2;
            }
            else if (filterTip2.Any() && !filterEtiketa2.Any() && filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterHumKar2.Intersect<Dogadjaj>(filterTip2);
                var d2 = d1.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d2;
            }
            else if (!filterTip2.Any() && filterEtiketa2.Any() && filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterHumKar2.Intersect<Dogadjaj>(filterEtiketa2);
                var d2 = d1.Intersect<Dogadjaj>(filterPosecenost2);
                listView.ItemsSource = d2;
            }
            else if (filterTip2.Any() && filterEtiketa2.Any() && filterHumKar2.Any() && filterPosecenost2.Any())
            {
                var d1 = filterHumKar2.Intersect<Dogadjaj>(filterTip2);
                var d2 = d1.Intersect<Dogadjaj>(filterPosecenost2);
                var d3 = d2.Intersect<Dogadjaj>(filterEtiketa2);
                listView.ItemsSource = d3;
            }
        }

        private void tip_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            List<string> oznakeT = new List<string>();
            List<string> oznakeD = new List<string>();

            var dog = (from d in listaDog where d.tip.Equals(c.Tag) select d);

            filterTip.AddRange(dog);         
        }

        private void tip_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            var dog = (from d in listaDog where d.tip.Equals(c.Tag) select d);

            foreach (var item in dog)
            {
                filterTip.Remove(item);
            }
        }

        private void etiketa_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            string a = c.Tag.ToString();

            var dog = (from d in listaDog where d.etiketa.Contains(a) select d);
            filterEtiketa.AddRange(dog);

           // var d1 = filterTip.Intersect<Dogadjaj>(filterEtiketa);
           // var d2 = d1.Intersect<Dogadjaj>(filterHumKar);
           // var d3 = d2.Intersect<Dogadjaj>(filterPosecenost);

           // listView.ItemsSource = d3;
        }

        private void etiketa_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            string a = c.Tag.ToString();

            var dog = (from d in listaDog where d.etiketa.Contains(a) select d);

            foreach (var item in dog)
            {
                filterEtiketa.Remove(item);
            }
        }

        private void humKar_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if (HumKarDa.IsChecked == true && HumKarNe.IsChecked == false)
            {
                var dog = (from d in listaDog where d.humanitarnog_karaktera.Equals("Da") select d);
                filterHumKar.AddRange(dog);               
            }
            else if (HumKarNe.IsChecked == true && HumKarDa.IsChecked == false)
            {
                var dog = (from d in listaDog where d.humanitarnog_karaktera.Equals("Ne") select d);
                filterHumKar.AddRange(dog);                
            }
            else if (HumKarNe.IsChecked == true && HumKarDa.IsChecked == true)
            {
                filterHumKar.Clear();
                var dog1 = (from d in listaDog where d.humanitarnog_karaktera.Equals("Da") select d);
                var dog2 = (from d2 in listaDog where d2.humanitarnog_karaktera.Equals("Ne") select d2);
                var dog = dog1.Concat(dog2);

                filterHumKar.AddRange(dog);            
            }
        }

        private void humKar_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if (HumKarDa.IsChecked == true && HumKarNe.IsChecked == false)
            {
                var dog = (from d in listaDog where d.humanitarnog_karaktera.Equals("Ne") select d);

                foreach (var item in dog)
                {
                    filterHumKar.Remove(item);
                }
            }
            else if (HumKarNe.IsChecked == true && HumKarDa.IsChecked == false)
            {
                var dog = (from d in listaDog where d.humanitarnog_karaktera.Equals("Da") select d);

                foreach (var item in dog)
                {
                    filterHumKar.Remove(item);
                }
            }
            else if (HumKarDa.IsChecked == false && HumKarNe.IsChecked == false)
            {
                filterHumKar.Clear();
            }
        }

        private void posecenost_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == false)// 1 0 0 0 
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == false)//0 1 0 0
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                filterPosecenost.AddRange(dog);  
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == false)//0 0 1 0
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == true)//0 0 0 1
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == false)//1 1 0 0 
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == false)//1 0 1 0
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == true)//1 0 0 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == false)//0 1 1 0
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == true)//0 1 0 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == true)//0 0 1 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == false)//1 1 1 0
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == true)//1 1 0 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == true)//1 0 1 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == true)//0 1 1 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                filterPosecenost.AddRange(dog);
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == true)//1 1 1 1
            {
                filterPosecenost.Clear();

                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog4 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog234 = dog123.Concat(dog3);
                var dog = dog234.Concat(dog4);

                filterPosecenost.AddRange(dog);
            }
        }

        private void posecenost_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == false)// 1 0 0 0 
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == false)//0 1 0 0
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == false)//0 0 1 0
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == true)//0 0 0 1
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog3 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog123 = dog1.Concat(dog2);
                var dog = dog123.Concat(dog3);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == false)//1 1 0 0 
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == false)//1 0 1 0
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == true)//1 0 0 1
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == false)//0 1 1 0
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == true)//0 1 0 1
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == true)//0 0 1 1
            {
                var dog1 = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);
                var dog2 = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);
                var dog = dog1.Concat(dog2);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == false)//1 1 1 0
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("Preko 10000") select d);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == true && p3.IsChecked == false && p4.IsChecked == true)//1 1 0 1
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("5000-10000") select d);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == true && p2.IsChecked == false && p3.IsChecked == true && p4.IsChecked == true)//1 0 1 1
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("1000-5000") select d);

                foreach (var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == true && p3.IsChecked == true && p4.IsChecked == true)//0 1 1 1
            {
                var dog = (from d in listaDog where d.posecenost_dogadjaja.Equals("Do 1000") select d);

                foreach(var item in dog)
                {
                    filterPosecenost.Remove(item);
                }
            }
            else if (p1.IsChecked == false && p2.IsChecked == false && p3.IsChecked == false && p4.IsChecked == false)//0 0 0 0
            {
                filterPosecenost.Clear();
            }
        }

        #endregion
    }
}
