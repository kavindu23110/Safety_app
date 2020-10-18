using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using System;

namespace Safety_app.Droid.NotificationHandlers
{
    public class NotificationHandler
    {
        private string CHANNELID = "230s223";
        private Context context { get; set; }

        public NotificationHandler()
        {
            context = global::Android.App.Application.Context;

        }



        [Obsolete]
        public void BuildNotification(string title, string text, string scheduleId)
        {
            PendingIntent pendingIntent = BulildActionToStart(scheduleId);
            Notification builder = BuildNotificationBuilder(title, text, pendingIntent);
            NotificationChannel channel = BuildNotificationChannel("MedicChannel");

            BuildNotificationManager(channel, builder);
        }



        private PendingIntent BulildActionToStart(string scheduleId)
        {
            const int pendingIntentId = 0;
            Intent intent = new Intent(context, typeof(MainActivity));

            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(context);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(intent);

            intent.PutExtra("ScheduleId", scheduleId);
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(context, pendingIntentId, intent, PendingIntentFlags.OneShot);

            return pendingIntent;
        }
        private void BuildNotificationManager(NotificationChannel notificationChannel, Notification notification)
        {
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager.CreateNotificationChannel(notificationChannel);
            notificationManager.Notify(0, notification);
        }

        [Obsolete]
        private Notification BuildNotificationBuilder(string title, string text, PendingIntent pendingIntent)
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                  .SetContentTitle(title)
                  .SetContentText(text)
                  .SetContentIntent(pendingIntent)
                  .SetPriority((int)NotificationPriority.High)
                  .SetChannelId(CHANNELID)
                  .SetVisibility((int)NotificationVisibility.Public)
                  .SetSmallIcon(global::Android.Resource.Drawable.SymDefAppIcon);
            builder.SetChannelId(CHANNELID);
            builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
            return builder.Build();
        }

        private NotificationChannel BuildNotificationChannel(string Name)
        {
            NotificationImportance importance = global::Android.App.NotificationImportance.High;
            NotificationChannel notificationChannel = new NotificationChannel(CHANNELID, Name, importance);
            notificationChannel.EnableLights(true);
            notificationChannel.EnableVibration(true);
            notificationChannel.LockscreenVisibility = NotificationVisibility.Public;
            notificationChannel.Name = "Medic APP";
            notificationChannel.ShouldVibrate();
            notificationChannel.Importance = NotificationImportance.High;
            notificationChannel.SetShowBadge(true);
            return notificationChannel;
        }




    }
}