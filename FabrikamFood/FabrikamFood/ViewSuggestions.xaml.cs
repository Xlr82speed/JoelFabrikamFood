using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using FabrikamFood.DataModels;

using Xamarin.Forms;

namespace FabrikamFood
{
    public partial class ViewSuggestions : ContentPage
    {
        public ViewSuggestions()
        {
            InitializeComponent();
        }

        async void Order_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("New Order",
                "Time Name Dish",
                "OK");
            await Navigation.PushModalAsync(new PlaceOrder());

        }
        
        private async void PrevSuggestions_Clicked(Object sender, EventArgs e)
        {

            List<Timeline> timelines = await AzureManager.AzureManagerInstance.GetTimelines();

            TimelineList.ItemsSource = timelines;

        }

    }
}
