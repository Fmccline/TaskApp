using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TaskIt_2017.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.InitNotification(new IOSNotification());
            LoadApplication(new App());

            //Asks for permission to send notifications
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

            if (options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
            {
                var localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                if(localNotification != null)
                {
                    HandleAlert(localNotification);
                }
            }

            return base.FinishedLaunching(app, options);
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            HandleAlert(notification);
        }

        private void HandleAlert(UILocalNotification notification)
        {
            UIAlertController alertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            Window.RootViewController.PresentViewController(alertController, true, null);

            //Reset the badge icon
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
    }
}
