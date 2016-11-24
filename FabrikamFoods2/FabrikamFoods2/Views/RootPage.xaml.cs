using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FabrikamFoods2
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
        }
    }
}
