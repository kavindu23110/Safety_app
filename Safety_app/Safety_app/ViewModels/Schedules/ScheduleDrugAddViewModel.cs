using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class ScheduleDrugAddViewModel : BaseViewModel
    {
        public string currentPrescription { get; set; }
        public string currentSchedule { get; set; }

        public ObservableCollection<Models.Drugs> lstselectedAllDrugs { get; set; }
        public ObservableCollection<Models.Drugs> lstScheduleDrugs { get; set; }


        public ICommand AddnewDrug { get; set; }
        public ICommand AddQuantity { get; set; }
        public ICommand SaveScheduleDrug { get; set; }
        public ICommand RemoveDrugFromListCommand { get; set; }

        public ScheduleDrugAddViewModel()
        {
            loadPrescription();

            lstselectedAllDrugs = new ObservableCollection<Models.Drugs>();
            lstScheduleDrugs = new ObservableCollection<Models.Drugs>();
            AddnewDrug = new Command(OnAddNewDrug);
            AddQuantity = new Command(OnAddQuantity);
            SaveScheduleDrug = new Command(OnSaveScheduleDrug);
            RemoveDrugFromListCommand = new Command(OnRemoveDrugFromList);


        }

        private void OnAddQuantity(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnRemoveDrugFromList(object obj)
        {
            if (obj != null)
            {
                lstselectedAllDrugs.Add((Models.Drugs)obj);
                lstScheduleDrugs.Remove((Models.Drugs)obj);
            }
        }

        private async void OnSaveScheduleDrug(object obj)
        {
             foreach (var drug in lstScheduleDrugs)
            {

                var current = await App.Database.GetDrugSchedulePrescriptionOperator().GetSelectedAsync(p => p.DrugId == drug.Id
                && p.IsActive == 1
                && p.PrescriptionId == currentPrescription
                && p.ScheduleId == currentSchedule);
                if (current != null)
                {
                    current.IsActive = 0;
                    await App.Database.GetDrugSchedulePrescriptionOperator().updateAsync(current);

                }
            
                await App.Database.GetDrugSchedulePrescriptionOperator().saveAsync(SetDrugSchedulePrescription(drug));
                
            }
            await AppShell.Current.GoToAsync("..");
        }

        private DrugSchedulePrescription SetDrugSchedulePrescription(Models.Drugs drug)
        {
            var obj = new DrugSchedulePrescription();
            obj.DrugId = drug.Id;
            obj.ScheduleId = currentSchedule;
            obj.PrescriptionId = currentPrescription;
            obj.Quantity = drug.Quantity;
            return obj;

        }

        private void OnAddNewDrug(object obj)
        {
            if (obj != null)
            {
                lstScheduleDrugs.Add((Models.Drugs)obj);
                lstselectedAllDrugs.Remove((Models.Drugs)obj);
            }
        }

        private void loadPrescription()
        {
            currentPrescription = StateManager.GetProperties<Prescription>("prescription").Id;

        }

        public async System.Threading.Tasks.Task loadPrescriptionDrugsAsync()
        {
            LoadAllprescriptiondrugsAsync();

            var dsp = await App.Database.GetDrugSchedulePrescriptionOperator().FindAsync(p => p.IsActive == 1 && p.PrescriptionId == currentPrescription && p.ScheduleId == currentSchedule);
            lstScheduleDrugs = new ObservableCollection<Models.Drugs>();
            foreach (var item in dsp)
            {
                var drug = await App.Database.GetDrugOperator().GetSelectedAsync(p => p.Id == item.DrugId && p.IsActive == 1);
                if (drug != null)
                {
                    drug.Quantity = item.Quantity;
                    lstScheduleDrugs.Add(drug);
                }
            }

        }



        private async void LoadAllprescriptiondrugsAsync()
        {
            lstselectedAllDrugs = StateManager.GetProperties<ObservableCollection<Models.Drugs>>(KeyValueDefinitions.lstselecteddrugs);
            if (lstselectedAllDrugs.Count() == 0)
            {
                var dsp = await App.Database.GetDrugSchedulePrescriptionOperator().FindAsync(p => p.IsActive == 1 && p.PrescriptionId == currentPrescription);
                var drugs = await App.Database.GetDrugOperator().FindAsync(p => (dsp.Select(s => s.DrugId).ToList()).Contains(p.Id) && p.IsActive == 1);
                lstselectedAllDrugs = new ObservableCollection<Models.Drugs>(drugs.ToList());
            }
        }
    }
}
