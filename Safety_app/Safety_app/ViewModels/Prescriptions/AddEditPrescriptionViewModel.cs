using Safety_app.Helpers;
using Safety_app.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Prescriptions
{
    public class AddEditPrescriptionViewModel
    {
        public Prescription prescription { get; set; }

        public ICommand savePrescription { get; }
        public ICommand ADDEditDrugs { get; private set; }
        public ICommand ADDEditSchedules { get; private set; }

        public AddEditPrescriptionViewModel()
        {

            savePrescription = new Command(OnsavePrescription);
            ADDEditDrugs = new Command(onAddDrugsAsync);
            ADDEditSchedules = new Command(onAddEditSchedules);
            prescription = new Prescription();
        }

        private async void onAddEditSchedules(object obj)
        {
            StateManager.StoreProperties<Prescription>(Safety_app.BOD.KeyValueDefinitions.Prescription, prescription);
            await Shell.Current.GoToAsync($"{nameof(Views.MainViews.Schedules.PrescriptionSchedule)}");

        }

        private async void onAddDrugsAsync(object obj)
        {
            StateManager.StoreProperties<Prescription>(Safety_app.BOD.KeyValueDefinitions.Prescription, prescription);
            await Shell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Drugs.index)}");
        }

        private async void OnsavePrescription(object obj)
        {
            await App.Database.GetPrescriptionOperator().saveAsync(prescription);
            await Shell.Current.GoToAsync("..");
        }
    }
}
