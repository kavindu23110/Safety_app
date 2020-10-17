using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using System;

[assembly: Permission(Name = "PACKAGEIDENTIFIER.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
[assembly: UsesPermission(Name = "PACKAGEIDENTIFIER.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
namespace Safety_app.Droid.BroadcastReciecvers
{

    [BroadcastReceiver(Permission = "com.google.android.c2dm.permission.SEND")]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]

    public class ScheduleReceiver : BroadcastReceiver
    {
        [Obsolete]
        public override void OnReceive(Context context, Intent intent)
        {
            PowerManager.WakeLock sWakeLock;
            var pm = PowerManager.FromContext(context);
            sWakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "GCM Broadcast Reciever Tag");
            sWakeLock.Acquire();
            if (!string.IsNullOrEmpty(intent.GetStringExtra("Id")))
            {
                NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                .SetContentTitle(intent.GetStringExtra("Name"))
                .SetShowWhen(true)
                .SetContentText(intent.GetStringExtra("Name"))
                .SetSmallIcon(2)
                .SetVisibility(1)
                .SetVibrate(new long[] { 1000, 1000 });

                NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                notificationManager.Notify(1, builder.Build());
                sWakeLock.Release();
            }


        }
    }
}