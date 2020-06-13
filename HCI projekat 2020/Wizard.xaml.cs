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

namespace HCI_projekat_2020
{
    /// <summary>
    /// Interaction logic for Wizard.xaml
    /// </summary>
    public partial class Wizard : Window
    {
        public static int click = 0;

        public Wizard()
        {
            InitializeComponent();
        }

        private void odustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void daljeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(click == 0)
            {
                ++click;
                nazadBtn.Visibility = Visibility.Visible;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w1.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;  
            }
            else if(click == 1)
            {
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w2.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
                ++click;
            }
            else if(click == 2)
            {
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w3.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
                ++click;
            }
            else if (click == 3)
            {
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w4.png"));
                slikaWizard.Stretch = Stretch.Uniform;
                ++click;
            }
            else if (click == 4)
            {
                ++click;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w5.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
                daljeBtn.Visibility = Visibility.Hidden;
                gotovoBtn.Visibility = Visibility.Visible;
            }
        }

        private void nazadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (click == 1)
            {
                --click;
                nazadBtn.Visibility = Visibility.Hidden;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/svet.jpg"));
                slikaWizard.Stretch = Stretch.UniformToFill;             
            }
            else if (click == 2)
            {
                --click;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w1.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
            }
            else if(click == 3)
            {
                --click;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w2.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
            }
            else if (click == 4)
            {
                --click;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w3.png"));
                slikaWizard.Stretch = Stretch.UniformToFill;
            }
            else if (click == 5)
            {
                --click;
                gotovoBtn.Visibility = Visibility.Hidden;
                daljeBtn.Visibility = Visibility.Visible;
                slikaWizard.Source = new BitmapImage(new Uri("pack://application:,,,/w4.png"));
                slikaWizard.Stretch = Stretch.Uniform;
            }
        }
   }
}
