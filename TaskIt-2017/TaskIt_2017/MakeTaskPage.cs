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

		private TaskItTaskEntries taskEntries;

		private Switch returnSwitch;

		public MakeTaskPage()
		{
			mainLayout = new StackLayout();
			taskEntries = new TaskItTaskEntries();

			returnSwitch = MakeDueDateSwitch();

			descriptionLayout = MakeDescriptionLayout();
			dueDateLayout = MakeHasDueDateLayout();

			mainLayout.Children.Add(taskEntries.Name);
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
					taskEntries.Description,
                }
            };
        }

		private StackLayout MakeHasDueDateLayout()
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
							returnSwitch,
						}
					}
				}
			};
		}

		private void ToggleAddDueDate(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				dueDateLayout.Children.Add(taskEntries.DueDate);
				dueDateLayout.Children.Add(taskEntries.DueTime);
			}
			else
			{
				dueDateLayout.Children.Remove(taskEntries.DueDate);
				dueDateLayout.Children.Remove(taskEntries.DueTime);
			}
		}

		private Switch MakeDueDateSwitch()
		{
			var returnSwitch = new Switch();
			returnSwitch.IsToggled = false;
			returnSwitch.Toggled += ToggleAddDueDate;
			return returnSwitch;
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
			task.Name = taskEntries.Name.Text;
			if (!String.IsNullOrEmpty(taskEntries.Description.Text))
            {
				task.Description = taskEntries.Description.Text;
            }
            if (returnSwitch.IsToggled)
            {
				task.DueDate = taskEntries.DueDate.Date + taskEntries.DueTime.Time;
            }
        }

        // If the task has a name: create a new task, add it to the database
        // Otherwise: display an alert asking to name the task
		private async void AddTaskButtonClicked(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(taskEntries.Name.Text))
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
