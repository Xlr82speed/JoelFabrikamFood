using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using FabrikamFood2.DataModels;
using Xamarin.Forms;

namespace FabrikamFoods2
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
            await Navigation.PushModalAsync(new PlaceOrder());

        }

        private async void PrevSuggestions_Clicked(Object sender, EventArgs e)
        {

            List<Timeline> timelines = await FabrikamFood2.AzureManager.AzureManagerInstance.GetTimelines();

            TimelineList.ItemsSource = timelines;

        }

    }
}

