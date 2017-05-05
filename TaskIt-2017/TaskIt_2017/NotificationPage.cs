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
        public NotificationPage()
        {
            var notificationButton = new Button {
                Text = "Send Notification",
                HorizontalOptions = LayoutOptions.Center
            };

            notificationButton.Clicked += async (object sender, EventArgs args) => {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        App.notificationHandler.notify(null);
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
    }
}
