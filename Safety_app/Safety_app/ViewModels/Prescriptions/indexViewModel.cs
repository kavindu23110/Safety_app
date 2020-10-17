using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Models;
using Safety_app.Views.MainViews.Prescriptions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Prescriptions
{
    public class indexViewModel : BaseViewModel
    {
        public ICommand addnewPrescription { get; }
        public ICommand Prescriptionselected { get; }
        public ICommand Prescriptiondelete { get; }

        public ObservableCollection<Prescription> lstprescription { get; set; }
        public Prescription selectedPrescription { get; set; }

        public indexViewModel()
        {
            addnewPrescription = new Command(OnaddnewPrescription);
            Prescriptionselected = new Command(OnPrescriptionselectedAsync);
            Prescriptiondelete = new Command(OnPrescriptiondeleteAsync);
            selectedPrescription = new Prescription();
        }

        private async void OnPrescriptiondeleteAsync(object obj)
        {
            if (!await StaticFunctions.DisplayAlert_DeleteAsync())
            {
                return;
            }
            var prescription = (Models.Prescription)obj;
            lstprescription.Remove(prescription);
            prescription.IsActive = 0;
            await App.Database.GetPrescriptionOperator().updateAsync(prescription);

        }

        private async void OnPrescriptionselectedAsync(object obj)
        {
            StateManager.StoreProperties<Prescription>(KeyValueDefinitions.Prescription, obj);
            await Shell.Current.GoToAsync($"{nameof(Views.MainViews.Schedules.PrescriptionSchedule)}");
        }

        private async void OnaddnewPrescription(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(AddEditPrescription)}");
        }
        private async void OnselectPrescription(object obj)
        {
            StateManager.StoreProperties<Prescription>(KeyValueDefinitions.Prescription, new Prescription());
            await Shell.Current.GoToAsync($"{nameof(AddEditPrescription)}");
        }

        public async System.Threading.Tasks.Task OnAppearing()
        {
            var list = await App.Database.GetPrescriptionOperator().FindAsync(p => p.IsActive == 1);
            lstprescription = new ObservableCollection<Prescription>(list);
        }


    }
}
