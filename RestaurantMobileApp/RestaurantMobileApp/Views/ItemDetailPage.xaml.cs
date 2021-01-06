using System.ComponentModel;
using Xamarin.Forms;
using RestaurantMobileApp.ViewModels;

namespace RestaurantMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}