using System.ComponentModel;
using Xamarin.Forms;
using Safety_app.ViewModels;

namespace Safety_app.Views
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