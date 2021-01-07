using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using System;
using System.Collections.Generic;
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
            this.getTableList();
        }

        async void getTableList()
        {

            Table[] tableList = null;
            tableList = await _restService.GetTableList();

            /*test.Text = tableList.Length.ToString();*/
            test.Text = tableList.GetType().ToString();




        }
    }
}