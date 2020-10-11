using Safety_app.Views.MainViews.Prescriptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Prescriptions
{
    public class AddEditPrescriptionViewModel
    {
        public ICommand savePrescription { get; }
        public ICommand ADDEditDrugs { get; private set; }
        public ICommand ADDEditSchedules { get; private set; }

        public AddEditPrescriptionViewModel()
        {

            savePrescription = new Command(OnsavePrescription);
            ADDEditDrugs = new Command(onAddDrugsAsync);
            ADDEditSchedules = new Command(onAddEditSchedules);
        }

        private async void onAddEditSchedules(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.index)}");
        }

        private async void onAddDrugsAsync(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Drugs.index)}");
        }

        private async void OnsavePrescription(object obj)
        {
            await Shell.Current.DisplayAlert("saved", "eyj", "cancel");
            await Shell.Current.GoToAsync("..");
        }
    }
}
