using SQLite;
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
		private TaskItTask task_;

		public ViewTaskPage(TaskItTask t)
		{
			task_ = t;

			Button delete_task_button = make_delete_task_button();
			delete_task_button.Clicked += delete_task;

			Content = new StackLayout
			{
				Children = {
					make_label("Name: " + task_.name),
					make_label("Description: " + task_.description),
					delete_task_button,
				}
			};
		}

		private Label make_label(string text)
		{
			return new Label { Text = text };
		}

		private Button make_delete_task_button()
		{
			var return_button = new Button
			{
				Text = "Delete Task",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};
			return_button.Clicked += delete_task;
			return return_button;
		}

		private async void delete_task(object sender, EventArgs e)
		{
			await App.database.delete_task_async(task_);
			await Navigation.PopAsync();
		}
	}
}
