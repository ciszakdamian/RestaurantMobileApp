using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RestaurantMobileApp.Models;
using RestaurantMobileApp.Services;
using Xamarin.Forms;

namespace RestaurantMobileApp.ViewModels
{
    public class NewTableViewModel : BaseViewModel
    {


        public NewTableViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public int number { get;  set; }

        public int places { get; set ; }

        public string description { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Table newTable = new Table()
            {
                number = number,
                places = places,
                description = description
            };
            RestService restService = new RestService();
            restService.PostTable(newTable);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
