using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace FabrikamFoods2
{
    public class MapPage : ContentPage
    {
        Map map;
        public MapPage()
        {
            map = new Map
            {
                //IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // You can use MapSpan.FromCenterAndRadius 
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-37, 175), Distance.FromMiles(300)));

            //anything north of the equator is +ve,south is -ve. East of GMT is +ve west of GMT is -ve.
            var PosSanfrancisco = new Position(37, -122); // Latitude, Longitude
            var PosMtRoskill = new Position(-36.9047, 174.7417); // Latitude, Longitude
            var PosGisborne = new Position(-38.6623, 178.0176); // Latitude, Longitude
            var PosNewPlymouth = new Position(-39.0556, 174.0752); // Latitude, Longitude
            var PosWellington = new Position(-41.2865, 174.7762); // Latitude, Longitude
            var PosQueensTown = new Position(-45.0312, 168.6626); // Latitude, Longitude
            var PosChristchurch = new Position(-43.5321, 172.6362); // Latitude, Longitude
            var PosRotterdam = new Position(51.9244, 4.4777); // Latitude, Longitude

            var PinSanfrancisco = new Pin
            {
                Type = PinType.Place,
                Position = PosSanfrancisco,
                Label = "Fabrikam Foods Sanfranciso",
                Address = "34 Sanfrincisco maridale ave"
            };
            var PinMtroskill = new Pin
            {
                Type = PinType.Place,
                Position = PosMtRoskill,
                Label = "Fabrikam Foods Mount Roskill",
                Address = "58 lancaster lane"
            };
            var PinGisborne = new Pin
            {
                Type = PinType.Place,
                Position = PosGisborne,
                Label = "Fabrikam Foods Gisborne",
                Address = "90 smooke screen ave"
            };
            var PinNewPlymouth = new Pin
            {
                Type = PinType.Place,
                Position = PosNewPlymouth,
                Label = "Fabrikam Foods PosNewPlymouth ",
                Address = "90 lavalake ave"
            };
            var PinWellington = new Pin
            {
                Type = PinType.Place,
                Position = PosWellington,
                Label = "Fabrikam Foods WEllington",
                Address = "45 butcher drive"
            };
            var PinQueensTown = new Pin
            {
                Type = PinType.Place,
                Position = PosQueensTown,
                Label = "Fabrikam Foods Queen's Town",
                Address = "200 Velvet road"
            };
            var PinChristchurch = new Pin
            {
                Type = PinType.Place,
                Position = PosChristchurch,
                Label = "Fabrikam Foods Christchurch",
                Address = "47 Ji company block"
            };
            var PinRotterdam = new Pin
            {
                Type = PinType.Place,
                Position = PosRotterdam,
                Label = "Fabrikam Foods Netherlands",
                Address = "300 Nathanya Ave"
            };


            map.Pins.Add(PinSanfrancisco);
            map.Pins.Add(PinMtroskill);
            map.Pins.Add(PinGisborne);
            map.Pins.Add(PinNewPlymouth);
            map.Pins.Add(PinWellington);
            map.Pins.Add(PinQueensTown);
            map.Pins.Add(PinChristchurch);
            map.Pins.Add(PinRotterdam);

            // add the slider
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                if (map.VisibleRegion != null)
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };


            // create map style buttons
            var street = new Button { Text = "Street" };
            var hybrid = new Button { Text = "Hybrid" };
            var satellite = new Button { Text = "Satellite" };
            street.Clicked += HandleClicked;
            hybrid.Clicked += HandleClicked;
            satellite.Clicked += HandleClicked;
            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { street, hybrid, satellite }
            };


            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            stack.Children.Add(segments);
            Content = stack;


            // for debugging output only
            map.PropertyChanged += (sender, e) => {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
                    CalculateBoundingCoordinates(map.VisibleRegion);
            };
        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
            }
        }



        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }
    }
}

