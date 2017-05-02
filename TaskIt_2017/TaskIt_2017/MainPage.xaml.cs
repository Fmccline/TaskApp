﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskIt_2017
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var title = new Label
            {
                Text = "TaskIt",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                Margin = new Thickness(40.0),
                HorizontalOptions = LayoutOptions.Center

            };

            var task = new Button
            {
                Text = "Task List Page",
                HorizontalOptions = LayoutOptions.Center
            };

            task.Clicked += async (object sender, EventArgs args) =>
            {
                await Navigation.PushAsync(new TaskListPage());
            };

            var calendar = new Button
            {
                Text = "Calendar",
                HorizontalOptions = LayoutOptions.Center
            };

            calendar.Clicked += async (object sender, EventArgs args) =>
            {
                await Navigation.PushAsync(new CalendarPage());
            };

            Content = new StackLayout
            {
                Children =
                {
                    title,
                    task,
                    calendar,
                }

            };

        }
    }
}
