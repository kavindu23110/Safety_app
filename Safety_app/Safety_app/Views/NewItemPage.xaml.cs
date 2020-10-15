using Safety_app.Models;
using Safety_app.ViewModels;
using Xamarin.Forms;

namespace Safety_app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}