using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public class ViewTaskPage : ContentPage
    {
        private TaskItTask task_;

        public ViewTaskPage(TaskItTask t)
        {
            task_ = t;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Name: " + task_.name },
                    new Label { Text = "Description: " + task_.description },
                    new Label { Text = "WOW" }
                }
            };
        }
    }
}
