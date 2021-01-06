using System;
using System.Collections.Generic;
using RestaurantMobileApp.ViewModels;
using RestaurantMobileApp.Views;
using Xamarin.Forms;

namespace RestaurantMobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
