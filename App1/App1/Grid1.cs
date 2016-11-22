﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Grid1 : ContentPage
    {
        int count = 1;

        public Grid1()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 20
            };

            var gridButton = new Button { Text = "To confirm you order\n Click Here." };
            gridButton.Clicked += delegate
            {
                gridButton.Text = string.Format("Your order has been sent successfully and should be ready in ", count--);
            };

            var listView = new ListView();
            listView.ItemsSource = new string[]{
            "Cakes",
            "Curry",
            "Fried Rice",
            "Roast Chicken",
            "Lasagne",
            "PPAP",
            "Biriani",
            "Lightly killed Bryn",
            "Flembé Quail"
            };
           
            layout.Children.Add(listView);
            layout.Children.Add(gridButton);
            Content = layout;

        }
    }
}