using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Settings;
using Microsoft.WindowsAzure.MobileServices;

namespace FabrikamFoods2
{
    public partial class MainPage : ContentPage
    {
        // Track whether the user has authenticated.
        bool authenticated = false;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string userId = CrossSettings.Current.GetValueOrDefault("user", "");
            string token = CrossSettings.Current.GetValueOrDefault("token", "");

            if (!token.Equals("") && !userId.Equals(""))
            {
                MobileServiceUser user = new MobileServiceUser(userId);
                user.MobileServiceAuthenticationToken = token;

                FabrikamFood2.AzureManager.AzureManagerInstance.AzureClient.CurrentUser = user;

                authenticated = true;
            }

            if (authenticated == true)
                this.loginButton.IsVisible = false;
        }

        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
                CrossSettings.Current.AddOrUpdateValue("user", FabrikamFood2.AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId);
                CrossSettings.Current.AddOrUpdateValue("token", FabrikamFood2.AzureManager.AzureManagerInstance.AzureClient.CurrentUser.MobileServiceAuthenticationToken);
            }
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
