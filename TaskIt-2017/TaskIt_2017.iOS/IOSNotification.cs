using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TaskIt_2017.iOS
{
    class IOSNotification : NotificationInterface
    {
        public void Notify(TaskItTask task)
        {
            if (task == null) return;

            UILocalNotification notification = new UILocalNotification();
            if (task.date_due == null)
                notification.FireDate = NSDate.FromTimeIntervalSinceNow(0);
            else
            notification.FireDate = (NSDate) task.date_due;
            notification.AlertTitle = task.name;
            notification.AlertAction = task.name;
            notification.AlertBody = task.description;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        public void NotifyMessage(string title, string message)
        {
            UILocalNotification notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(0);
            notification.AlertTitle = title;
            notification.AlertAction = title;
            notification.AlertBody = message;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}