using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using DotLiquid.Util;

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