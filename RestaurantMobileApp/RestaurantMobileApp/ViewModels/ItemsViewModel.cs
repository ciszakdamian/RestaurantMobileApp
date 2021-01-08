using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using RestaurantMobileApp.Models;
using RestaurantMobileApp.Views;
using RestaurantMobileApp.Services;

namespace RestaurantMobileApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Table _selectedTable;

        public ObservableCollection<Table> Tables { get; }
        public Command LoadTablesCommand { get; }
        public Command AddTableCommand { get; }
        public Command<Table> TableTapped { get; }

        public ItemsViewModel()
        {
            Title = "Stoliki";
            Tables = new ObservableCollection<Table>();
            LoadTablesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            TableTapped = new Command<Table>(OnTableSelected);

            AddTableCommand = new Command(OnAddTable);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Tables.Clear();
                RestService _restService = new RestService();
                var items = await _restService.GetTableList();
                foreach (var item in items)
                {
                    Tables.Add(item);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTable = null;
        }

        public Table SelectedTable
        {
            get => _selectedTable;
            set
            {
                SetProperty(ref _selectedTable, value);
                OnTableSelected(value);
            }
        }

        private async void OnAddTable(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTablePage));
        }

        async void OnTableSelected(Table item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(TableDetailPage)}?{nameof(TableDetailViewModel.ItemId)}={item.id}");
        }
    }
}