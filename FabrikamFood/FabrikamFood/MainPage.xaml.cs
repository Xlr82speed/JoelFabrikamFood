using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using FabrikamFood.DataModels;

namespace FabrikamFood
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Menu!",
                "Out variety of dishes '" + button.Text + "' made by the finest chefs",
                "browse");
            await Navigation.PushModalAsync(new Menu());

        }

        async void OnButtonClicked2(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Our branches",
                "Use Google map's API to find the closest branch near you",
                "OK");
            await Navigation.PushModalAsync(new MapPage());

        }

        private async void ViewTimeline_Clicked(Object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new ViewSuggestions());

        }


    }
}
