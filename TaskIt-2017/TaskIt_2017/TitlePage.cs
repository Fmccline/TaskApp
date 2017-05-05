using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace TaskIt_2017
{
    public partial class TitlePage : ContentPage
    {
        public TitlePage()
        {
            Title = "TaskIt";
           
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

            Image myImage = new Image
            {
                Source = "star.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            var notification = new Button
            {
                Text = "Notification Test",
                HorizontalOptions = LayoutOptions.Center
            };


            notification.Clicked += async (object sender, EventArgs args) =>
            {
                await Navigation.PushAsync(new NotificationPage());
            };

            Content = new StackLayout
            {
                Children =
                {                                                     
                    task,
                    calendar,
                    notification,
                    myImage,
                }
            };
        }
    }
}
