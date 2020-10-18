using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Views.MainViews.Schedules;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class Index : BaseViewModel
    {
        public ICommand SelectScheduleCommand { get; set; }
        public ICommand Scheduledelete { get; set; }
        public ICommand ScheduleEdit { get; }
        public ObservableCollection<Models.Shedule> lstSchedules { get; set; }

        public Index()
        {
            SelectScheduleCommand = new Command(OnSelectSchedule);
            Scheduledelete = new Command(OnScheduledeleteAsync);
            ScheduleEdit = new Command(OnScheduleEditAsync);

        }

        private async void OnScheduleEditAsync(object obj)
        {

            var schedule = (Models.Shedule)obj;
            StateManager.StoreProperties<Models.Shedule>(KeyValueDefinitions.ScheduleEdit, schedule);
            await Shell.Current.GoToAsync($"{nameof(AddEditSchedule)}");
        }

        private async void OnScheduledeleteAsync(object obj)
        {
            if (!await StaticFunctions.DisplayAlert_DeleteAsync())
            {
                return;
            }

            var schedule = (Models.Shedule)obj;

            var lst = await App.Database.GetDrugSchedulePrescriptionOperator().FindAsync(p => p.ScheduleId == schedule.Id && p.IsActive == 1);
            foreach (var item in lst)
            {
                item.IsActive = 0;
                await App.Database.GetDrugSchedulePrescriptionOperator().updateAsync(item);
            }
            lstSchedules.Remove(schedule);
            schedule.IsActive = 0;
            await App.Database.GetScheduleOperator().updateAsync(schedule);
        }

        private void OnSelectSchedule(object obj)
        {

        }

        public async Task LoadSchedulesAsync()
        {
            var lst = await App.Database.GetScheduleOperator().FindAsync(p => p.IsActive == 1);
            lstSchedules = new ObservableCollection<Models.Shedule>(lst);
        }
    }
}
