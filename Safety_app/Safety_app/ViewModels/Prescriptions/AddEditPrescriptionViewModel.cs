using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Prescriptions
{
    public class AddEditPrescriptionViewModel
    {
        public Prescription prescription { get; set; }
        public bool isEdit = false;
        public ICommand savePrescription { get; }
        public ICommand ADDEditDrugs { get; private set; }
        public ICommand ADDEditSchedules { get; private set; }

        public AddEditPrescriptionViewModel()
        {

            savePrescription = new Command(OnsavePrescription);
            ADDEditDrugs = new Command(onAddDrugsAsync);
            ADDEditSchedules = new Command(onAddEditSchedules);
            prescription = new Prescription();
            loadprescription();
        }

        private void loadprescription()
        {
            prescription = StateManager.GetProperties<Prescription>(KeyValueDefinitions.PrescriptionEdit);
            StateManager.Remove(KeyValueDefinitions.PrescriptionEdit);
            isEdit = !string.IsNullOrEmpty(prescription.Name);
        }

        private async void onAddEditSchedules(object obj)
        {
            StateManager.StoreProperties<Prescription>(Safety_app.BOD.KeyValueDefinitions.Prescription, prescription);
           // await Shell.Current.GoToAsync($"{nameof(Views.MainViews.Schedules.PrescriptionSchedule)}");
            await Shell.Current.Navigation.PushAsync(new Views.MainViews.Schedules.PrescriptionSchedule(), true);

        }

        private async void onAddDrugsAsync(object obj)
        {
            StateManager.StoreProperties<Prescription>(Safety_app.BOD.KeyValueDefinitions.Prescription, prescription);
            await Shell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Drugs.index)}");
        }

        private async void OnsavePrescription(object obj)
        {
            if (isEdit)
            {
                await App.Database.GetPrescriptionOperator().updateAsync(prescription);
            }
            else
            {
                await App.Database.GetPrescriptionOperator().saveAsync(prescription);
            }
            await Shell.Current.Navigation.PopToRootAsync(true);
            // await Shell.Current.GoToAsync("..");
        }
    }
}
