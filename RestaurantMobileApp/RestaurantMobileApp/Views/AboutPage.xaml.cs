using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMobileApp.Views
{
    public partial class AboutPage : ContentPage
    {
        RestService _restService;
        public AboutPage()
        {

            InitializeComponent();
            _restService = new RestService();
        }

        void onClick(object sender, EventArgs e)
        {
            var item = new {description = Order.Text, number = TableNumber.Text, places = PeopleNumber.Text, price = Price.Text };
            _restService.PostOrder(item);
            DisplayAlert("Info", "Zamówienie zostalo złożone", "OK");
        }
    }
}