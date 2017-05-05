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
    public class NotificationService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            App.NotificationHandler.NotifyMessage("Service Message", "Notification service started");
            return null;
        }
    }
}