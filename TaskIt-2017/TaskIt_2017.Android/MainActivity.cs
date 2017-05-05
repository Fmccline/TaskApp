using System;

using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TaskIt_2017.Droid
{
    [Activity(Label = "TaskIt_2017", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        private static readonly int ButtonClickNotificationId = 420;
        NotificationManager notificationManager;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
            makeNotification(null);
        }

        private void makeNotification(TaskItTask task)
        {
            Notification.Builder builder = new Notification.Builder(this)
                .SetContentTitle("Test notification")
                .SetContentText("This is the content of the test notification")
                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                .SetSmallIcon(Resource.Drawable.star);

            notificationManager.Notify(ButtonClickNotificationId, builder.Build());
        }
    }
}

