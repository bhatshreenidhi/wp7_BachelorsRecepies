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
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace BachelorsRecepies
{
    public partial class RecepiePage : PhoneApplicationPage
    {
        ObservableCollection<Model.Recepie> lstItems = new ObservableCollection<Model.Recepie>();
        ObservableCollection<string> lstIng = new ObservableCollection<string>();


        public RecepiePage()
        {
            InitializeComponent();

            panaromaCtrl.Title = Model.Item.selectedItemName.ToLower();

            LoadRecepie();

        }

        private void LoadRecepie()
        {
            string str = Model.Item.selectedItem;

            string fileName = "Recepie1.xml";

            XElement element = XElement.Load(fileName);

            var nodeLists = from ele1 in element.Descendants("Item")
                            where ele1.Element("Number").Value == Model.Item.selectedItem 
                            select new
                            {
                                desc = ele1.Element("Desc").Value,
                                ing = ele1.Elements("Ingredients").Elements("Items")
                            };


            foreach (var nod in nodeLists)
            {
                Model.Recepie item = new Model.Recepie();
                item.itemDesc = nod.desc;
                foreach (var ingredients in nod.ing)
                {
                    lstIng.Add(ingredients.Value);
                }
                lstItems.Add(item);
            }

            lstIngredients.ItemsSource = lstIng;
            lstRecepie.ItemsSource = lstItems;
        }
    }
}