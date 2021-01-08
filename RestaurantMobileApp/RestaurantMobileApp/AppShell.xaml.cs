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
            Routing.RegisterRoute(nameof(TableDetailPage), typeof(TableDetailPage));
            Routing.RegisterRoute(nameof(NewTablePage), typeof(NewTablePage));
        }

    }
}
