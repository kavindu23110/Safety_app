using Safety_app.ViewModels.Notification;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.NotificationView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrugConflicts : ContentPage
    {
     

        public DrugConflicts(System.Collections.Generic.List<Models.DrugSchedulePrescription> currentdrugwithothers)
        {
            InitializeComponent();
            BindingContext = new DrugConflictViewModel(currentdrugwithothers);
        }


    }
}
