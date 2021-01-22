using RestaurantMobileApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantMobileApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {

        private Order _selectedOrder;

        public ObservableCollection<Order> Orders { get; }
        public Command LoadOrdersCommand { get; }
        public Command<Order> OrderTapped { get; }

        public OrdersViewModel()
        {
            Title = "Zamowienia";
            
            Orders = new ObservableCollection<Order>();

            LoadOrdersCommand = new Command(async () => await ExecuteLoadOrdersCommand());

            OrderTapped = new Command<Order>(OnOrderSelected);
            
        }

        async Task ExecuteLoadOrdersCommand()
        {

        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                OnOrderSelected(value);
            }
        }

        async void OnOrderSelected(Order item)
        {
           
        }
    }
}