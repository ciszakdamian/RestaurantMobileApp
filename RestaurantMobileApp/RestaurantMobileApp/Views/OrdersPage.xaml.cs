
using RestaurantMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {

        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = new OrdersViewModel();
        }
    }
}