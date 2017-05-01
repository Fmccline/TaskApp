using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public class MakeTaskPage : ContentPage
    {
        private Entry name_entry_;
        private Entry description_entry_;


        public MakeTaskPage()
        {
            name_entry_ = make_entry("Task Name");
            description_entry_ = make_entry("Task Description");

            Content = main_layout();
        }

        private Entry make_entry(string placeholder)
        {
            return new Entry
            {
                Placeholder = placeholder
            };
        }

        private StackLayout main_layout()
        {
            Button add_task_button = make_add_task_button();

            return new StackLayout
            {
                Children =
                {
                    name_entry_,
                    description_entry_,
                    add_task_button,
                }
            };
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

        private async void add_task_button_clicked(object sender, EventArgs e)
        {
            string name_entry = name_entry_.Text;
            string description_entry = description_entry_.Text;
            TaskItTask new_task = new TaskItTask(name_entry,description_entry);

            await App.database.save_task_async(new_task);
            await DisplayAlert("Task Added", "The task has been created!", "Right on!");
        }
    }
}
