using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BachelorsRecepies.Model
{
    public class Item
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public static string selectedItem;
        public static string selectedItemName;
    }
}
