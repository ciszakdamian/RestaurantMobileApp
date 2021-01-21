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
        private string itemId;
        public int Id { get; set; }

        public int text { get; set; }

        public string description { get; set; }

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
                var table = await restService.GetTable(Convert.ToInt32(itemId));
                Id = table.id;
                text = table.number;
                description = table.description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
