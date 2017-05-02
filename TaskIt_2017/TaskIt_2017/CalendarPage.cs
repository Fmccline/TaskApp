using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            var go_back = new Button
            {
                Text = "Go Back Test",
                HorizontalOptions = LayoutOptions.Center
            };

            go_back.Clicked += async (object s, EventArgs a) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Calendar" },
                    go_back,
                }
            };
        }
    }
}
