using Safety_app.ViewModels.Prescriptions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPrescription : ContentPage
    {
        public AddEditPrescription()
        {
            InitializeComponent();
            BindingContext = new AddEditPrescriptionViewModel();
        }
    }
}