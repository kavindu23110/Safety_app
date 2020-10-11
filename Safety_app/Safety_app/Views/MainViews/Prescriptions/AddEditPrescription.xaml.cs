using Safety_app.ViewModels.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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