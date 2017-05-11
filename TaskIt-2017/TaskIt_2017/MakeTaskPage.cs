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
		private StackLayout mainLayout;
		private StackLayout dueDateLayout;
		private StackLayout descriptionLayout;

		private Entry nameEntry;
		private Editor descriptionEntry;
		private DatePicker dueDateEntry;
		private TimePicker dueTimeEntry;

		private Switch dueDateSwitch;

		public MakeTaskPage()
		{
			mainLayout = new StackLayout();

			nameEntry = MakeEntry("Task Name");
            descriptionEntry = new Editor();

			dueDateSwitch = MakeDueDateSwitch();
			dueDateEntry = MakeDueDate();
			dueTimeEntry = MakeDueTime();

			descriptionLayout = MakeDescriptionLayout();
			dueDateLayout = MakeDueDateLayout();

			mainLayout.Children.Add(nameEntry);
			mainLayout.Children.Add(descriptionLayout);
			mainLayout.Children.Add(dueDateLayout);
			mainLayout.Children.Add(MakeAddTaskButton());

			Content = mainLayout;
		}

        private StackLayout MakeDescriptionLayout()
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
                    descriptionEntry,
                }
            };
        }

		private StackLayout MakeDueDateLayout()
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
							dueDateSwitch,
						}
					}
				}
			};
		}

		private void ToggleAddDueDate(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				dueDateLayout.Children.Add(dueDateEntry);
				dueDateLayout.Children.Add(dueTimeEntry);
			}
			else
			{
				dueDateLayout.Children.Remove(dueDateEntry);
				dueDateLayout.Children.Remove(dueTimeEntry);
			}
		}

		private Switch MakeDueDateSwitch()
		{
			var dueDateSwitch = new Switch();
			dueDateSwitch.IsToggled = false;
			dueDateSwitch.Toggled += ToggleAddDueDate;
			return dueDateSwitch;
		}

		private DatePicker MakeDueDate()
		{
			return new DatePicker
			{
				Date = DateTime.Now,
				MinimumDate = DateTime.Now,
			};
		}

		private TimePicker MakeDueTime()
		{
            return new TimePicker
            {
                Time = new TimeSpan(6, 0, 0),
			};
		}

		private Entry MakeEntry(string placeholder)
		{
			return new Entry
			{
				Placeholder = placeholder
			};
		}

		private Button MakeAddTaskButton()
		{
			Button returnButton = new Button
			{
				Text = "Add Task",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};
			returnButton.Clicked += AddTaskButtonClicked;
			return returnButton;
		}

        // Set a TaskItTask to the entry name, 
        // possible description, and possible due date
		private void SetTask(TaskItTask task)
        {
            task.Name = nameEntry.Text;
            if (!String.IsNullOrEmpty(descriptionEntry.Text))
            {
                task.Description = descriptionEntry.Text;
            }
            if (dueDateSwitch.IsToggled)
            {
                task.DueDate = dueDateEntry.Date + dueTimeEntry.Time;
            }
        }

        // If the task has a name: create a new task, add it to the database
        // Otherwise: display an alert asking to name the task
		private async void AddTaskButtonClicked(object sender, EventArgs e)
		{
            if (!String.IsNullOrEmpty(nameEntry.Text))
            {
				TaskItTask newTask = new TaskItTask();
                SetTask(newTask);

                await App.Database.SaveTaskAsync(newTask);
                App.NotificationHandler.Notify(newTask);
                await DisplayAlert("Task Added", "The task has been created!", "Right on!");
            }
            else
            {
                await DisplayAlert("Oops", "Please enter a name for the Task!", "Righto");
            }
		}
	}
}
