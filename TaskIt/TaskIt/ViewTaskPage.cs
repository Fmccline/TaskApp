using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt
{
    public class ViewTaskPage : ContentPage
    {
        private TaskItTask task_;

        public ViewTaskPage(TaskItTask task)
        {
            task_ = task;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = task_.name },
                    new Label { Text = task_.description}
                }
            };
        }
    }
}
