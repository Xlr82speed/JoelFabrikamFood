using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabrikamFood.DataModels;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace FabrikamFood
{
    public class PlaceOrder2 : ContentPage
    {

        Dictionary<string, int> Dish3 = new Dictionary<string, int>
        {
            {"Foodl" , 0}, {"Food2", 1 }, {"Food3", 2 },{"Food4", 2 }
        };

        Dictionary<string, int> rating = new Dictionary<string, int>
        {
            {"1" , 0}, {"2", 1 }, {"3", 2 }
        };
        public static String DishEntry;
        public static String RatingEntry;
        public PlaceOrder2()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            Picker DishSelect = new Picker
            {
                Title = "Dish Eaten",

            };

            foreach (string Dish3 in Dish3.Keys)
            {
                DishSelect.Items.Add(Dish3);
            }

            Picker RatingSelect = new Picker
            {
                Title = "Enter Your rating here",

            };

            foreach (string rating in rating.Keys)
            {
                RatingSelect.Items.Add(rating);

            }

            DishSelect.SelectedIndexChanged += (sender, args) =>
            {
                DishEntry = DishSelect.Items[DishSelect.SelectedIndex];
            };

            RatingSelect.SelectedIndexChanged += (sender, args) =>
            {
                RatingEntry = RatingSelect.Items[RatingSelect.SelectedIndex];
            };

            var blahbutton = new Button { Text = "Enter Your feelings" };
            blahbutton.Clicked += blahbuttonclicked;

            layout.Children.Add(DishSelect);
            layout.Children.Add(RatingSelect);
            layout.Children.Add(blahbutton);

            Content = layout;


        }


        private async void blahbuttonclicked(object sender, EventArgs e)
        {


            Timeline customerRating = new Timeline()
            {
                Dish = DishEntry,
                Rating = RatingEntry
                    //Date = DateTime.Now
           };
            await AzureManager.AzureManagerInstance.AddTimeline(customerRating);
            

        }
    }
}
