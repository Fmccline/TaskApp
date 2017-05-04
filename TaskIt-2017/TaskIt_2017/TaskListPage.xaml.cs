using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace TaskIt_2017
{
    public partial class TaskListPage : ContentPage
    {
        private ListView tasks_lv_;

        public TaskListPage()
        {
            InitializeComponent();


            Content = make_task_layout();
        }

        protected override async void OnAppearing()
        {
            tasks_lv_.ItemsSource = await App.database.get_tasks_async();
        }


        // Creates the layout for the page
        // Includes: SearchBar, ListView for tasks, Button for adding tasks
        private StackLayout make_task_layout()
        {
            StackLayout stack_layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    make_search_bar(),
                    make_tasks_lv(),
                    make_add_task_button(),
                }
            };

            return stack_layout;
        }
    
        private ListView make_tasks_lv()
        {       
            tasks_lv_ = new ListView();
            tasks_lv_.ItemTemplate = new DataTemplate(make_task_vc);
            tasks_lv_.ItemSelected += async (sender, e) =>
            {
                TaskItTask selected_task = (TaskItTask)e.SelectedItem;
                await Navigation.PushAsync(new ViewTaskPage(selected_task));
            };

            return tasks_lv_;
        }

        private Button make_add_task_button()
        {
            Button return_button = new Button
            {
                Text = "Add Task",
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            return_button.Clicked += add_task_button_clicked;
            return return_button;
        }

        private SearchBar make_search_bar()
        {
            return new SearchBar
            {
                Placeholder = "Search for task...",
                SearchCommand = new Command(() =>
                {
                    DisplayAlert("Howdy!", "You searched for something! WOW!", "WOW indeed!");
                   
                })
                 
            // TODO: SearchCommand needs to eventually search for a task
        };
        }

        private ViewCell make_task_vc()
        {
            Label task_name = new Label();
            task_name.SetBinding(Label.TextProperty, "name");
            task_name.HorizontalTextAlignment = TextAlignment.Center;

            return new ViewCell { View = new ContentView { Content = task_name } };
        }

        private async void add_task_button_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeTaskPage());
        }

    }
}
