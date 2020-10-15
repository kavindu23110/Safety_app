
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Drugs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewDrug : ContentPage
    {
        public AddNewDrug()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Drugs.AddNewdrugViewModel();
        }
    }
}