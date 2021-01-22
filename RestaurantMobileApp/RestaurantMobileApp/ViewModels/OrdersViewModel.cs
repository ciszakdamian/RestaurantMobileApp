using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantMobileApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {

        public ObservableCollection<Order> Orders { get; }
        public Command LoadOrdersCommand { get; }
        public Command<Order> OrderTapped { get; }

        public OrdersViewModel()
        {
            Title = "Zamowienia";
            
            Orders = new ObservableCollection<Order>();

            LoadOrdersCommand = new Command(async () => await ExecuteLoadOrdersCommand());
            
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadOrdersCommand()
        {
            IsBusy = true;

            try
            {
                Orders.Clear();
                RestService _restService = new RestService();
                var items = await _restService.GetOrderList();
                foreach (var item in items)
                {
                    Orders.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}