using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Safety_app.Droid.BroadcastReciecvers;

namespace Safety_app.Droid
{
   public class NotificationService : Service
    {
        private static BroadcastReceiver notificationReceiver;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            RegisterBroadcastReceiver();
        }

        public override void OnDestroy()
        {
            Application.Context.UnregisterReceiver(notificationReceiver);
            notificationReceiver = null;
        }

        private void RegisterBroadcastReceiver()
        {
            notificationReceiver = new ScheduleReceiver();

            IntentFilter filter = new IntentFilter("com.xamarin.example.TEST");
            Application.Context.RegisterReceiver(notificationReceiver, filter);
        }
    }
}