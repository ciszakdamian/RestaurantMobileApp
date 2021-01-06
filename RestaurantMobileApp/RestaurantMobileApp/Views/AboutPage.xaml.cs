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
            this.getTable();
        }

        async void getTable()
        {
            Table table = await _restService.GetTable(1);
            if (table != null)
            {
                Order.Text = table.description;
                TableNumber.Text = "" + table.number;
                PeopleNumber.Text = "" + table.places;
            }
        }

        void onClick(object sender, EventArgs e)
        {

            var item = new {description = Order.Text, number = TableNumber.Text, places = PeopleNumber.Text};
            _restService.PostOrder(item);
        }
    }
}