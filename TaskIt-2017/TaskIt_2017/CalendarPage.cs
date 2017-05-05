using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace TaskIt_2017
{
    public class CalendarPage : ContentPage
    {
        Grid grid;
        public CalendarPage()
        {
            Title = DateTime.Now.ToString("M");

            grid = makeCalendar();

            Content = new StackLayout
            {
                Children =
                {
                    grid,
                }
            };
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var col = grid.ColumnDefinitions;
            var row = grid.RowDefinitions;

            grid.WidthRequest = width;
            grid.HeightRequest = height;

            foreach(var c in col)
            {
                c.Width = width / 7.5;
            }
            
            foreach(var r in row)
            {
                r.Height = height / 6.5;
            }

        }

        private Grid makeCalendar()
        {
            int startDayOffset = 0;
            var startDay = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            List<string> d = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            foreach (var ds in d)
            {
                if (startDay.DayOfWeek.ToString() == ds)
                    break;
                startDayOffset++;
            }

            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int monthLength = DateTime.DaysInMonth(year, month);

            //temp sizes - see OnSizeAllocated()
            int ht = 50, wd = 50;
            int pad = 5, space = 2;

            grid = new Grid
            {
                Padding = new Thickness(pad),
                RowSpacing = space,
                ColumnSpacing = space,
                BackgroundColor = Color.Tomato,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            for (int x = 0; x < 7; x++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = wd });

                for (int y = 0; y < 6; y++)
                {
                    var day = 7 * y + x;

                    grid.RowDefinitions.Add(new RowDefinition { Height = ht });
                    var label = new Label();

                    DateTime taskDate = startDay.AddDays(day - startDayOffset);

                    populateTasks(label, taskDate);


                    if (day - startDayOffset < monthLength && day >= startDayOffset)
                    {
                        label.Text = (day - startDayOffset + 1).ToString() + "\n";
                        label.Font = Font.SystemFontOfSize(NamedSize.Micro);

                        if (day == DateTime.Now.Day)
                        {
                            label.BackgroundColor = Color.RosyBrown;
                        }
                        else label.BackgroundColor = Color.Tan;

                        grid.Children.Add(label, x, y);
                    }
                }
            }

            return grid;
        }

        private async Task<List<TaskItTask>> getTask()
        {
            return await App.database.get_tasks_async();
        }
       
        private async void populateTasks(Label label, DateTime taskDate)
        {
            var list = new List<TaskItTask>();
            string desc = "";

            try
            {
                var waiter = await getTask();
                list = waiter;               
            }catch(Exception e) { label.Text += "error"; desc = e.Message; }
          
            foreach (var task in list)
            {
                if (task.date_due.Date == taskDate.Date)
                {
                    label.Text += task.name + "\n";
                    desc += task.description + "\n";
                }
            }

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, EventArgs args) =>
              {
                  await DisplayAlert(taskDate.ToString("M"), desc, "OK");
              };

            if (desc != "")
                label.GestureRecognizers.Add(tap);
           
        }


    }

}