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
            Notification.Builder builder = new Notification.Builder(context_)
                   .SetContentTitle("Test notification")
                   .SetContentText("This is the content of the test notification")
                   .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                   .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                   .SetSmallIcon(Resource.Drawable.star);

            notificationManager.Notify(ButtonClickNotificationId, builder.Build());
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