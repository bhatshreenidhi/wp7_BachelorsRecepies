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
using System.Collections.Generic;

namespace BachelorsRecepies.Model
{
    public class Recepie
    {
        public string itemDesc { get; set; }
        public string Number { get; set; }
        public static string selectedItem;
    }
}
