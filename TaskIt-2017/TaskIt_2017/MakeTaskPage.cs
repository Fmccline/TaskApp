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
        private ObservableCollection<TaskItTask> tasks_;
        private Entry name_entry_;
        private Entry description_entry_;


        public MakeTaskPage(ObservableCollection<TaskItTask> tasks)
        {
            tasks_ = tasks;
            name_entry_ = make_name_entry();
            description_entry_ = make_description_entry();

            Content = main_layout();
        }

        private Entry make_description_entry()
        {
            return new Entry
            {
                Placeholder = "Task description"
            };
        }

        private Entry make_name_entry()
        {
            return new Entry
            {
                Placeholder = "Task Name"
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

        private void add_task_button_clicked(object sender, EventArgs e)
        {
            string name_entry = name_entry_.Text;
            string description_entry = description_entry_.Text;
            TaskItTask new_task = new TaskItTask(name_entry,description_entry);
            tasks_.Add(new_task);
            DisplayAlert("Task Added", "The task has been created!", "Right on!");
        }
    }
}
