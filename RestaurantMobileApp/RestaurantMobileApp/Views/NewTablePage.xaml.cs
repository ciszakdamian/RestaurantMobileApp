using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RestaurantMobileApp.Models;
using RestaurantMobileApp.ViewModels;

namespace RestaurantMobileApp.Views
{
    public partial class NewTablePage : ContentPage
    {
        public Table Table { get; set; }

        public NewTablePage()
        {
            InitializeComponent();
            BindingContext = new NewTableViewModel();
        }
    }
}