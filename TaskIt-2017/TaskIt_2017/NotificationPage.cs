using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public class NotificationPage : ContentPage
    {
#if __ANDROID__
        NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
#endif
        public NotificationPage()
        {
            var notificationButton = new Button {
                Text = "Send Notification",
                HorizontalOptions = LayoutOptions.Center
            };

            notificationButton.Clicked += async (object sender, EventArgs args) => {
                switch(Device.RuntimePlatform)
                {
                    case Device.Android:
                        await Navigation.PushAsync(new TitlePage());
                        break;

                    case Device.iOS:
                        break;
                }
            };


            Content = new StackLayout
            {
                Children = {
                    notificationButton
                }
            };
        }

#if __ANDROID__

        private void makeNotification(TaskItTask task)
        {
            Notification.Builder builder = new Notification.Builder (this)
                .SetContentTitle("Test notification")
                .SetContentText("This is the content of the test notification")
                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                .SetSmallIcon(Resource.Drawable.ic_notification);

            notificationManager.Notify (0, builder.Build());
        }

#endif
    }
}
