using System;
using System.Diagnostics;
using System.Threading.Tasks;
using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using Xamarin.Forms;

namespace RestaurantMobileApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TableDetailViewModel : BaseViewModel
    {
        public TableDetailViewModel()
        {
            AddReservation = new Command(OnReserve);
            MakeFree = new Command(OnFree);
            AddOrder = new Command(OnOrder);
        }

        private string itemId;

        private int number;
        private string description;
        private string state;
        public int Id { get; set; }

        public int Number 
        { 
            get { return number; }
            set { SetProperty(ref number, value); } 
        }

        public string Description 
        { 
            get { return description; }
            set { SetProperty(ref description, value); } 
        }

        public string State 
        { 
            get { return state; }
            set { SetProperty(ref state, value); } 
        }

        public Command AddReservation { get; }
        public Command MakeFree { get; }
        public Command AddOrder { get; }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                RestService restService = new RestService();
                Table table = await restService.GetTable(Convert.ToInt32(itemId));
                Id = table.id;
                Number = table.number;
                Description = table.description;
                State = table.state;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private void OnReserve()
        {
            RestService restService = new RestService();
            restService.setTableStatus(Id, "reserved");
        }

        private void OnFree()
        {
            RestService restService = new RestService();
            restService.setTableStatus(Id, "free");

        }

        private void OnOrder()
        { 
           // await Shell.Current.GoToAsync($"{nameof(TableDetailPage)}?{nameof(TableDetailViewModel.ItemId)}={Id}");
        }
    }
}
