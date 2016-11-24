using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabrikamFood2.DataModels;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using FabrikamFood2;

namespace FabrikamFoods2
{
    public class PlaceOrder : ContentPage
    {

        Dictionary<string, int> Dish3 = new Dictionary<string, int>
        {
            {"Meal of the Day1" , 0}, {"Meal of the Day2", 1 }, {"Meal of the Day3", 2 }
        };

        Dictionary<string, int> rating = new Dictionary<string, int>
        {
            {"1" , 0}, {"2", 1 }, {"3", 2 }, {"4", 3 }, {"5", 4 }
        };
        public static String DishEntry = "blank";
        public static String RatingEntry = "Blaurg";
        public PlaceOrder()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            Picker DishSelect = new Picker
            {
                Title = "Select the meal of the day",

            };

            foreach (string Dish3r in Dish3.Keys)
            {
                DishSelect.Items.Add(Dish3r);
            }

            Picker RatingSelect = new Picker
            {
                Title = "Your rating",

            };

            foreach (string ratingr in rating.Keys)
            {
                RatingSelect.Items.Add(ratingr);

            }

            DishSelect.SelectedIndexChanged += (sender, args) =>
            {
                DishEntry = DishSelect.Items[DishSelect.SelectedIndex];
            };

            RatingSelect.SelectedIndexChanged += (sender, args) =>
            {
                RatingEntry = RatingSelect.Items[RatingSelect.SelectedIndex];
            };

            var blahbutton = new Button { Text = "Submit rating" };
            blahbutton.Clicked += blahbuttonclicked;

            layout.Children.Add(DishSelect);
            layout.Children.Add(RatingSelect);
            layout.Children.Add(blahbutton);

            Content = layout;


        }


        private async void blahbuttonclicked(object sender, EventArgs e)
        {

            //try
            //{
                Timeline customerRating = new Timeline()
                {
                    Dish = DishEntry,
                    Rating = RatingEntry,
                    Date = DateTime.Now
                };
                await AzureManager.AzureManagerInstance.AddTimeline(customerRating);
           // }
            //catch (Exception ex)
           // {
                //null
           // }


        }
    }
}