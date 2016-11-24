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
    public partial class PlaceOrder : ContentPage
    {
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {

            Timeline Order = new Timeline()
            {
                Dish = name.Text
            };
            await AzureManager.AzureManagerInstance.AddTimeline(Order);
        }
    }
}
