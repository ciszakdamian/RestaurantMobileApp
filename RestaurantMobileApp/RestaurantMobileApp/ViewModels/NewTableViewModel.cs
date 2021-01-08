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

        private int number;
        private int places;
        private string description;

        public NewTableViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public int Number
        {
            get => Number;
            set => SetProperty(ref number, value);
        }

        public int Places
        {
            get => Places;
            set => SetProperty(ref places, value);
        }

        public string Description
        {
            get => Description;
            set => SetProperty(ref description, value);
        }

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
                number = Number,
                places = Places,
                description = Description
            };
            RestService restService = new RestService();
            restService.PostOrder(newTable);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
