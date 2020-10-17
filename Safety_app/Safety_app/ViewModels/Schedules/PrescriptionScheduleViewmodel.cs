using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Models;
using Safety_app.Views.MainViews.Schedules;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{

    public class PrescriptionScheduleViewmodel : BaseViewModel
    {


        public ICommand addnewSchedule { get; }
        public ICommand AddSelectedSchedule { get; }
        public ICommand Scheduleselected { get; }
        public ICommand RemoveScheduleFromListCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ScheduleEdit { get; }

        public ObservableCollection<Models.Shedule> lstSchedules { get; set; }
        public ObservableCollection<Models.Shedule> lstSelectedSchedules { get; set; }
        public string currentPrescription { get; private set; }

        public PrescriptionScheduleViewmodel()
        {
            addnewSchedule = new Command(AddNewschedule);
            lstSelectedSchedules = new ObservableCollection<Models.Shedule>();
            AddSelectedSchedule = new Command(OnAddSelectedschedule);
            Scheduleselected = new Command(OnScheduleselectedAsync);
            ScheduleEdit = new Command(OnScheduleEditAsync);
            SaveCommand = new Command(OnSaveCommandAsync);
            RemoveScheduleFromListCommand = new Command(OnRemoveScheduleFromListCommand);
            loadPrescription();
        }

        private async void OnScheduleEditAsync(object obj)
        {
            var schedule = (Models.Shedule)obj;
            StateManager.StoreProperties<Models.Shedule>(KeyValueDefinitions.ScheduleEdit, schedule);
            await Shell.Current.GoToAsync($"{nameof(AddEditSchedule)}");
        }

        private async void OnSaveCommandAsync(object obj)
        {
            await AppShell.Current.GoToAsync($"..");

        }

        private void loadPrescription()
        {
            currentPrescription = StateManager.GetProperties<Prescription>(KeyValueDefinitions.Prescription).Id;


        }

        private void OnRemoveScheduleFromListCommand(object obj)
        {
            if (obj != null)
            {
                var schedule = (Models.Shedule)obj;
                lstSchedules.Add(schedule);
                lstSelectedSchedules.Remove(schedule);
            }
        }

        private async void OnScheduleselectedAsync(object obj)
        {
            StateManager.StoreProperties<Models.Shedule>(KeyValueDefinitions.Schedule, obj);
            await AppShell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.ScheduleDrugAdd)}");
        }

        private void OnAddSelectedschedule(object obj)
        {
            if (obj != null)
            {
                var schedule = (Models.Shedule)obj;
                lstSelectedSchedules.Add(schedule);
                lstSchedules.Remove(schedule);
            }
        }

        public async System.Threading.Tasks.Task LoadSchedulesAsync()
        {
            var shedules = await App.Database.GetScheduleOperator().FindAsync(p => p.IsActive == 1);
            lstSchedules = new ObservableCollection<Models.Shedule>(shedules);
            loadAssignedSchedulesAsync();

        }


        public async void loadAssignedSchedulesAsync()
        {

            var selectedScheduleIds = await App.Database.GetDrugSchedulePrescriptionOperator().FindAsync(p => p.IsActive == 1 && p.PrescriptionId == currentPrescription);
            var lstselected = lstSchedules.Where(p => (selectedScheduleIds.ToList().Select(s => s.ScheduleId)).Contains(p.Id) && p.IsActive == 1).ToList();
            lstSelectedSchedules = new ObservableCollection<Models.Shedule>(lstselected);
            foreach (var item in lstSelectedSchedules)
            {
                lstSchedules.Remove(item);
            }
        }

        private void AddNewschedule(object obj)
        {
            AppShell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.AddEditSchedule)}");
        }
    }
}
