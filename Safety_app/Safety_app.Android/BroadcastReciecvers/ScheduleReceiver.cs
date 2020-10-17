using Android.App;
using Android.Content;
using Android.Support.V4.App;
using System;

namespace Safety_app.Droid.BroadcastReciecvers
{
    [BroadcastReceiver]
    public class ScheduleReceiver : BroadcastReceiver
    {
        [Obsolete]
        public override void OnReceive(Context context, Intent intent)
        {
            if (!string.IsNullOrEmpty(intent.GetStringExtra("Id")))
            {
                NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                .SetContentTitle(intent.GetStringExtra("Name"))
                .SetShowWhen(true)
                .SetContentText(intent.GetStringExtra("Name"))
                .SetSmallIcon(2)
                .SetVisibility(1)
                .SetVibrate(new long[] { 1000, 1000 });

                NotificationManager notificationManager =
                    (NotificationManager)context.GetSystemService(Context.NotificationService);
                notificationManager.Notify(1, builder.Build());
            }


        }
    }
}