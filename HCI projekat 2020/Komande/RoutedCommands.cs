using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_projekat_2020.Komande
{
    public static class RoutedCommands
    {
        public static readonly RoutedUICommand Izađi = new RoutedUICommand(
            "Izađi",
            "Izađđi",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt),
                new KeyGesture(Key.F4, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand ManipulacijaDogađajima = new RoutedUICommand(
            "Manipulacija Događajima",
            "ManipulacijaDogađajima",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control),
                new KeyGesture(Key.D, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand ManipulacijaTipovima = new RoutedUICommand(
            "Manipulacija Tipovima",
            "ManipulacijaTipovima",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control),
                new KeyGesture(Key.T, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand ManipulacijaEtiketama = new RoutedUICommand(
            "Manipulacija Etiketama",
            "ManipulacijaEtiketama",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control),
                new KeyGesture(Key.E, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand UkloniEntitet = new RoutedUICommand(
            "Ukloni Entitet",
            "UkloniEntitet",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.U, ModifierKeys.Control),
                new KeyGesture(Key.U, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand PretraziEntitete = new RoutedUICommand(
            "Pretrazi Entitete",
            "PretraziEntitete",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control),
                new KeyGesture(Key.S, ModifierKeys.Alt | ModifierKeys.Control)
            });
    }
}
