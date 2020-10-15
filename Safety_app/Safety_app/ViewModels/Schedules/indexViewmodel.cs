using Safety_app.Views.MainViews.Schedules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class indexViewmodel : BaseViewModel
    {


        public ICommand addnewSchedule { get; }
        public ICommand AddSelectedSchedule { get; }
        public ICommand Scheduleselected { get; }
        public ICommand RemoveScheduleFromListCommand { get; }

        public ObservableCollection<Models.Shedule> lstSchedules { get; set; }
        public ObservableCollection<Models.Shedule> lstSelectedSchedules { get; set; } 

        public indexViewmodel()
        {
            addnewSchedule = new Command(AddNewschedule);
           lstSelectedSchedules= new ObservableCollection<Models.Shedule>();
            AddSelectedSchedule = new Command(OnAddSelectedschedule);
            Scheduleselected = new Command(OnScheduleselectedAsync);
            RemoveScheduleFromListCommand = new Command(OnRemoveScheduleFromListCommand);
    
        }

        private void OnRemoveScheduleFromListCommand(object obj)
        {
            if (obj != null)
            {
                var schedule = (Models.Shedule)obj;
                lstSchedules.Add(schedule);
                lstSelectedSchedules .Remove(schedule);
            }
        }

        private async void OnScheduleselectedAsync(object obj)
        {
            //var x = new Views.MainViews.Schedules.ScheduleDrugAdd();
            //await AppShell.Current.Navigation.PushModalAsync(x);
            await AppShell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.ScheduleDrugAdd)}");
        }

        private void OnAddSelectedschedule(object obj)
        {
            if (obj !=null)
            {
                var schedule = (Models.Shedule)obj;
                lstSelectedSchedules.Add(schedule);
                lstSchedules.Remove(schedule);
            }
        }

        public async System.Threading.Tasks.Task LoadSchedulesAsync()
        {
            var shedules = await App.Database.GetScheduleOperator().GetAsync();
           lstSchedules = new ObservableCollection<Models.Shedule>(shedules);
        }
        private void AddNewschedule(object obj)
        {
            AppShell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.AddEditSchedule)}");
        }
    }
}
