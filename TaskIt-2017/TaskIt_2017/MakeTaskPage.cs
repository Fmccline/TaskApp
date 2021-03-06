﻿using System;
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
		private StackLayout main_layout_;
		private StackLayout due_date_layout_;
        private StackLayout description_layout_;

		private Entry name_entry_;
		private Editor description_entry_;
		private DatePicker due_date_entry_;
		private TimePicker due_time_entry_;

		private Switch due_date_switch_;

		public MakeTaskPage()
		{
			main_layout_ = new StackLayout();

			name_entry_ = make_entry("Task Name");
            description_entry_ = new Editor();

            due_date_switch_ = make_due_date_switch();
			due_date_entry_ = make_due_date();
			due_time_entry_ = make_due_time();

            description_layout_ = make_description_layout();
			due_date_layout_ = make_due_date_layout();

			main_layout_.Children.Add(name_entry_);
			main_layout_.Children.Add(description_layout_);
			main_layout_.Children.Add(due_date_layout_);
			main_layout_.Children.Add(make_add_task_button());

			Content = main_layout_;
		}

        private StackLayout make_description_layout()
        {
            return new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Description",
                        FontAttributes = FontAttributes.Bold
                    },
                    description_entry_,
                }
            };
        }

		private StackLayout make_due_date_layout()
		{
			return new StackLayout
			{
				Children =
				{
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						Children =
						{
							new Label {Text = "Has Due Date"},
							due_date_switch_,
						}
					}
				}
			};
		}

		private void toggle_add_due_date(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				due_date_layout_.Children.Add(due_date_entry_);
				due_date_layout_.Children.Add(due_time_entry_);
			}
			else
			{
				due_date_layout_.Children.Remove(due_date_entry_);
				due_date_layout_.Children.Remove(due_time_entry_);
			}
		}

		private Switch make_due_date_switch()
		{
			var due_date_switch = new Switch();
			due_date_switch.IsToggled = false;
			due_date_switch.Toggled += toggle_add_due_date;
			return due_date_switch;
		}

		private DatePicker make_due_date()
		{
			return new DatePicker
			{
				Date = DateTime.Now,
				MinimumDate = DateTime.Now,
			};
		}

		private TimePicker make_due_time()
		{
            return new TimePicker
            {
                Time = new TimeSpan(6, 0, 0),
			};
		}

		private Entry make_entry(string placeholder)
		{
			return new Entry
			{
				Placeholder = placeholder
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

        // set_task
        // Set a TaskItTask to the entry name, 
        // possible description, and possible due date
        private void set_task(TaskItTask task)
        {
            task.name = name_entry_.Text;
            if (!String.IsNullOrEmpty(description_entry_.Text))
            {
                task.description = description_entry_.Text;
            }
            if (due_date_switch_.IsToggled)
            {
                task.date_due = due_date_entry_.Date + due_time_entry_.Time;
            }
        }

        // add_task_button_clicked
        // If the task has a name: create a new task, add it to the database
        // Otherwise: display an alert asking to name the task
		private async void add_task_button_clicked(object sender, EventArgs e)
		{
            if (!String.IsNullOrEmpty(name_entry_.Text))
            {
                TaskItTask new_task = new TaskItTask();
                set_task(new_task);

                await App.database.save_task_async(new_task);
                App.NotificationHandler.Notify(new_task);
                await DisplayAlert("Task Added", "The task has been created!", "Right on!");
            }
            else
            {
                await DisplayAlert("Oops", "Please enter a name for the Task!", "Righto");
            }
		}
	}
}
