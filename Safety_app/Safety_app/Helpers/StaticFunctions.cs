using Safety_app.DependancyService;
using Safety_app.Models;
using Xamarin.Forms;

namespace Safety_app.Helpers
{
    public static class StaticFunctions
    {
        public static async System.Threading.Tasks.Task<bool> DisplayAlert_DeleteAsync()
        {
            return await Application.Current.MainPage.DisplayAlert("Reminder", "This Action Will Delete Item Permanently", "OK", "cancel");
        }
        public static void ActivateSchedule(Shedule shedule)
        {
            ITaskSchedular taskSchedular = DependencyService.Get<ITaskSchedular>();
            taskSchedular.TimerAddSchedule(shedule);

        }
        public static void DeActivateSchedule(Shedule shedule)
        {
            ITaskSchedular taskSchedular = DependencyService.Get<ITaskSchedular>();
            taskSchedular.TimerDeactivateSchedule(shedule);
        }


    }
}
