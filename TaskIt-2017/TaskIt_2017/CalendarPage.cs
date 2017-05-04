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

        public CalendarPage()
        {
            Title = "Calendar";

            int startDayOffset=0;
            var startDay = DateTime.Now.AddDays(-DateTime.Now.Day+1);
            List<string> d = new List<string>{ "Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday" };
            foreach(var ds in d)
            {               
                if (startDay.DayOfWeek.ToString() == ds)
                    break;
                startDayOffset++;
            }
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int monthLength = DateTime.DaysInMonth(year, month);   
            var date = DateTime.Now.ToString("M");       
        

            //this needs platform screen size functions I think
            //need to read landscape/normal view too
            //windows default
          //  int wid = Convert.ToInt32(CalendarPage.WidthProperty.ToString());
          //  int hei = Convert.ToInt32(CalendarPage.HeightProperty.ToString());
            int ht = 100, wd = 100;
            int pad = 10, space = 5;

            switch (Device.RuntimePlatform)
            {
                case "Android":
                    ht = 50;
                    wd = 50;
                    pad = 5;
                    space = 2;
                    break;                
                default:
                    break;
            }

            int ght = 6 * ht + 2 * pad + 5 * space, gwd = 7 * wd + 2 * pad + 6 * space;

            var grid = new Grid
            {
                Padding = new Thickness(pad),            
                RowSpacing = space,
                ColumnSpacing = space,
                BackgroundColor = Color.Tomato,
                HeightRequest = ght,
                WidthRequest = gwd,
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

                    DateTime taskDate= startDay.AddDays(day - startDayOffset);

                    populate(label, taskDate);
    

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

            Content = new StackLayout
            {

                Children =
                {
                    new Label{Text = date, HorizontalOptions=LayoutOptions.Center, },
                    grid,
                }
            };
        }
    
        private async Task<List<TaskItTask>> getTask(DateTime time)
        {
            return await App.database.get_tasks_by_date(time);
        }
       
        private async void populate(Label label ,DateTime taskDate)
        {
            var list = new List<TaskItTask>();
            
            try
            {
                var waiter = await getTask(taskDate);
                list = waiter;               
            }catch(Exception e) { label.Text += e.Message; }
          
            foreach (var task in list)
            {
                label.Text += task.name + "\n";
            }
        }


    }

}