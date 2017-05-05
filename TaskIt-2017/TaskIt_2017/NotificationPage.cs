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
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Add notification tests here" }
                }
            };
        }

        private void makeNotification(TaskItTask task)
        {

        }
    }
}
