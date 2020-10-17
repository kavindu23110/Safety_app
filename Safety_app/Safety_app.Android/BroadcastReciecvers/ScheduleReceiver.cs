using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;
using Safety_app.Droid.NotificationHandlers;
using System;

[assembly: Permission(Name = "PACKAGEIDENTIFIER.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
[assembly: UsesPermission(Name = "PACKAGEIDENTIFIER.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
namespace Safety_app.Droid.BroadcastReciecvers
{

 //   [BroadcastReceiver(Permission = "com.google.android.c2dm.permission.SEND")]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new[] { "com.xamarin.example.TEST" })]
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class ScheduleReceiver : BroadcastReceiver
    {
        [Obsolete]
        public override void OnReceive(Context context, Intent intent)
        {
            Context x=context.ApplicationContext;
            PowerManager.WakeLock sWakeLock;
            var pm = PowerManager.FromContext(context);
            sWakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "GCM Broadcast Reciever Tag");
            sWakeLock.Acquire();

           var ScheduleId = intent.Extras.Get("Id");
            var ScheduleName = intent.Extras.Get("Name");
            if (ScheduleId != null)
            {
                
                NotificationHandler handler = new NotificationHandler();
                handler.BuildNotification((string)ScheduleName, "Prescription time is began.Tap to Continue",(string)ScheduleId);

            }
            sWakeLock.Release();

        }
    }
}