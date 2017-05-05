using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

namespace TaskIt_2017.Droid
{
    [BroadcastReceiver]
    public class NotificationAlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var id = intent.GetIntExtra("id", 0);
            var title = intent.GetStringExtra("title");
            var message = intent.GetStringExtra("message");
            Notification.Builder notificationBuilder = new Notification.Builder(context)
                  .SetSmallIcon(Resource.Drawable.star)
                  .SetContentTitle(title)
                  .SetContentText(message);
            var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(421 + id, notificationBuilder.Build());
        }
    }
}