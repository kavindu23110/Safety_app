using Safety_app.DependancyService;
using Safety_app.DependancyServices;
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
        public static async void DisplayAlert_ProvideInformationAsync(string title, string details)
        {
            await Application.Current.MainPage.DisplayAlert(title, details, "OK");
        }
        public static void ActivateSchedule(Shedule shedule, long miliseconds)
        {
            ITaskSchedular taskSchedular = DependencyService.Get<ITaskSchedular>();
            taskSchedular.TimerAddSchedule(shedule,miliseconds);

        }
        public static void DeActivateSchedule(Shedule shedule)
        {
            ITaskSchedular taskSchedular = DependencyService.Get<ITaskSchedular>();
            taskSchedular.TimerDeactivateSchedule(shedule);
        }
        public static void ToastMessage_Long(string message)
        {
            IMessage toast = DependencyService.Get<IMessage>();
            toast.LongAlert(message);
        }  
        public static void ToastMessage_Short(string message)
        {
            IMessage toast = DependencyService.Get<IMessage>();
            toast.ShortAlert(message);
        }


    }
}
