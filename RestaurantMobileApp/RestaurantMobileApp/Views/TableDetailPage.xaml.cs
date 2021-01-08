using System.ComponentModel;
using Xamarin.Forms;
using RestaurantMobileApp.ViewModels;

namespace RestaurantMobileApp.Views
{
    public partial class TableDetailPage : ContentPage
    {
        public TableDetailPage()
        {
            InitializeComponent();
            BindingContext = new TableDetailViewModel();
        }
    }
}