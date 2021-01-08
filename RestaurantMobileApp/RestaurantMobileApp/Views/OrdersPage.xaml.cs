using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {


        RestService _restService;


        public OrdersPage()
        {
            InitializeComponent();

            _restService = new RestService();

            this.GetTableList();
        }

        public async void GetTableList()
        {

            Table[] tableList = null;
            tableList = await _restService.GetTableList();

            foreach (var order in tableList)
            {
                number.Text = order.number.ToString();
                places.Text = order.places.ToString();
                description.Text = order.description.ToString();
            }

        }
    }
}