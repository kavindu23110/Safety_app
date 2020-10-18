using Android.App;
using Android.Content;
using Android.OS;
using Safety_app.DependancyService;
using Safety_app.Droid.BroadcastReciecvers;
using Safety_app.Models;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Safety_app.Droid.DependancyServices.AlarmManagerService))]
namespace Safety_app.Droid.DependancyServices
{

    public class AlarmManagerService : ITaskSchedular
    {

        [Obsolete]
        public void TimerAddSchedule(Shedule shedule,long miliseconds)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(ScheduleReceiver));
            alarmIntent.PutExtra("Id", shedule.Id);
            alarmIntent.PutExtra("Name", shedule.Name);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
            alarmManager.Set(AlarmType.RtcWakeup, miliseconds, pendingIntent);
    
        }


        [Obsolete]
        public void TimerDeactivateSchedule(Shedule shedule)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(ScheduleReceiver));
            alarmIntent.PutExtra("Id", shedule.Id);
            alarmIntent.PutExtra("Name", shedule.Name);
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.CancelCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(pendingIntent);
        }
    }
}