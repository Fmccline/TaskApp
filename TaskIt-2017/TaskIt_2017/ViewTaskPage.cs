using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
	public class ViewTaskPage : ContentPage
	{
		private TaskItTask task;

		public ViewTaskPage(TaskItTask t)
		{
			task = t;

            var layout = new StackLayout();
			AddTaskAttributesToLayout(layout);
			AddDeleteButtonToLayout(layout);

			Content = layout;
		}

        private void AddTaskAttributesToLayout(StackLayout layout)
        {
			foreach (var label in task.GetDisplayLabels())
            {
          		layout.Children.Add(label);
            }
        }

		private void AddDeleteButtonToLayout(StackLayout layout)
		{
			var deleteTaskButton = new Button
			{
				Text = "Delete Task",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};
			deleteTaskButton.Clicked += DeleteTask;
            layout.Children.Add(deleteTaskButton);
		}

		private async void DeleteTask(object sender, EventArgs e)
		{
			await App.Database.DeleteTaskAsync(task);
			await Navigation.PopAsync();
		}
	}
}
