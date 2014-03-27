using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using BachelorsRecepies.Model;

namespace BachelorsRecepies
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static int type;
        ObservableCollection<Model.Item> lstItems = new ObservableCollection<Model.Item>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            LoadMenu();
        }

        private void LoadMenu()
        {
            XElement element = XElement.Load("Items.xml");

            var nodeLists = from ele1 in element.Descendants("Item")
                            where ele1.Element("Type").Value == type.ToString()
                            select new
                            {
                                name = ele1.Element("Name").Value,
                                number = ele1.Element("Number").Value
                            };

            foreach (var nod in nodeLists)
            {
                Model.Item item = new Model.Item();
                item.Name = nod.name;
                item.Number = nod.number;
                lstItems.Add(item);
            }

            lstMenu.ItemsSource = lstItems;
        }

        private void txbMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Item txb = (Item)(sender as TextBlock).DataContext;
            Item.selectedItem = txb.Number;
            Item.selectedItemName = txb.Name;
            NavigationService.Navigate(new Uri("/RecepiePage.xaml",UriKind.RelativeOrAbsolute));


        }
    }
}