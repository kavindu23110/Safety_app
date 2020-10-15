using Safety_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}