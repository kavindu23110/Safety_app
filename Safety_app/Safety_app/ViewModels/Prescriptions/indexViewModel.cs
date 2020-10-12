using Safety_app.Views;
using Safety_app.Views.MainViews.Prescriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Prescriptions
{
 public   class indexViewModel:BaseViewModel
    {
        public ICommand addnewPrescription { get; }

        public indexViewModel()
        {
            addnewPrescription = new Command(OnaddnewPrescription);
        }

        private async void OnaddnewPrescription(object obj)
        {
         await Shell.Current.GoToAsync($"{nameof(AddEditPrescription)}");
        
        }
    }
}
