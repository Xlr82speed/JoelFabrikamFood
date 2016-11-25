using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FabrikamFoods2
{
    public class Menu : ContentPage
    {

        public Menu()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 20
            };



            var listView = new ListView();
            listView.ItemsSource = new string[]{
            "                                   MENU",
            "$23      Cakes",
            "$25      Curry",
            "$23      Fried Rice",
            "$23      Roast Chicken",
            "$23      Lasagne",
            "$23      PPAP",
            "$23      Biriani",
            "$22      Lightly killed Bryn",
            "$23      Flembé Quail",
            "$23      Lasagne",
            "$23      PPAP",
            "$25      Biriani",
            "$23      Lasagne",
            "$13      PPAP",
            "$23      Biriani",
            "$15      Lasagne",
            "$13      PPAP",
            "$23      Biriani"
            };

            layout.Children.Add(listView);
            Content = layout;

        }
    }
}