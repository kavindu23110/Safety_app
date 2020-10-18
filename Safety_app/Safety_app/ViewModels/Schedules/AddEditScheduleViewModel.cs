using Safety_app.BOD;
using Safety_app.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class AddEditScheduleViewModel : BaseViewModel
    {
        public bool edit = false;
        public ICommand SaveSchedule { get; }
        public Models.Shedule Shedule { get; set; }
        public AddEditScheduleViewModel()
        {

            SaveSchedule = new Command(OnSaveScheduleAsync);

            Shedule = new Models.Shedule();
        }



        private async void OnSaveScheduleAsync(object obj)
        {

            if (edit)
            {
                StaticFunctions.ToastMessage_Long("Schedule Updated Successfully");
                await App.Database.GetScheduleOperator().updateAsync(Shedule);
            }
            else
            {
                StaticFunctions.ToastMessage_Long("Schedule Added Successfully");
                await App.Database.GetScheduleOperator().saveAsync(Shedule);
            }
            await Shell.Current.GoToAsync("..");
        }

        internal void LoadSchedulesAsync()
        {
            var schedulecache = StateManager.GetProperties<Models.Shedule>(KeyValueDefinitions.ScheduleEdit);
            StateManager.Remove(KeyValueDefinitions.ScheduleEdit);
            Shedule = schedulecache;
            if (Shedule.Name != null)
            {
                edit = true;
            }

        }
    }
}
