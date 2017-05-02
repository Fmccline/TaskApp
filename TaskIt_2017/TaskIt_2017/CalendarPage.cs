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
            Title = "Calendar";
            //for testing navigation issues
            /* var go_back = new Button
             {
                 Text = "Go Back Test",
                 HorizontalOptions = LayoutOptions.Center
             };

             go_back.Clicked += async (object s, EventArgs a) =>
             {
                 await Navigation.PopAsync();
             };*/



           

            var month = DateTime.Now.ToString("M");
            var today = DateTime.Now.DayOfWeek.ToString();



            //this needs platform screen size functions I think
            //need to read landscape/normal view too
            //windows default

            int ht = 100, wd = 100;
            int pad = 10, space = 5;
            
            switch(Device.RuntimePlatform)
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
                    if (day <= 31 && day > 0)
                        grid.Children.Add(new Label
                        {
                            Text = day.ToString(),
                            Font = Font.SystemFontOfSize(NamedSize.Small),
                            BackgroundColor = Color.Tan,                            
                        }, x, y);
                }
            }

        Content = new StackLayout
            {
            
                Children =
                {
                    new Label{Text = month, HorizontalOptions=LayoutOptions.Center, },
                    grid,
                }
            };
        }

        private Grid _grid()
        {
            var grid = new Grid
            {
                RowSpacing = 40,
                ColumnSpacing = 40,
                BackgroundColor = Color.Tomato,
                
            };

            return grid;
        }
    }
}
