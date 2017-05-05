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

namespace TaskIt_2017.Droid
{
    [Service(Label = "NotificationService")]
    public class NotificationService : IntentService
    {
        public NotificationService() : base("NotificationService")
        {

        }

        protected override void OnHandleIntent(Intent intent)
        {;
            Console.WriteLine("Starting notification intent service");
            Notification.Builder notificationBuilder = new Notification.Builder(this)
             .SetSmallIcon(Resource.Drawable.star)
             .SetContentTitle("Service message")
             .SetContentText("Starting Intent service");
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(421, notificationBuilder.Build());
        }
    }
}