using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace TaskIt_2017.Droid
{
    class AndroidNotification : NotificationInterface
    {
        private readonly int ButtonClickNotificationId = 420;
        public NotificationManager notificationManager;
        private Context context_;

        public AndroidNotification(Context context)
        {
            context_ = context;
            notificationManager = context_.GetSystemService(Context.NotificationService) as NotificationManager;
        }

        public void Notify(TaskItTask task)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(NotificationAlarmReceiver));
            if (task == null) return;

            alarmIntent.PutExtra("id", task.id);
            alarmIntent.PutExtra("title", task.name);
            alarmIntent.PutExtra("message", task.description);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

            long time = 0;
            if (task.date_due != null)
                time = (task.date_due.Ticks - DateTime.Now.Ticks) / TimeSpan.TicksPerMillisecond;
            alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + time, pendingIntent);
        }

        public void NotifyMessage(string title, string message)
        {
            Notification.Builder builder = new Notification.Builder(context_)
                   .SetContentTitle(title)
                   .SetContentText(message)
                   .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                   .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                   .SetSmallIcon(Resource.Drawable.star);
        }
    }

}