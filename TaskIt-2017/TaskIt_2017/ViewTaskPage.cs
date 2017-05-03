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

            var layout = new StackLayout();
            add_task_attributes_to_layout(layout);
            add_delete_button_to_layout(layout);

			Content = layout;
		}

        private void add_task_attributes_to_layout(StackLayout layout)
        {
            var display_attributes = task_.get_display_attributes();
            foreach (KeyValuePair<string, string> kvp in display_attributes)
            {
                Label attribute_name = make_label(kvp.Key);
                attribute_name.FontAttributes = FontAttributes.Bold;
                Label attribute_value = make_label(kvp.Value);

                layout.Children.Add(attribute_name);
                layout.Children.Add(attribute_value);
            }
        }

		private Label make_label(string text)
		{
			return new Label { Text = text };
		}

		private void add_delete_button_to_layout(StackLayout layout)
		{
            var delete_task_button = new Button
			{
				Text = "Delete Task",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};
			delete_task_button.Clicked += delete_task;
            layout.Children.Add(delete_task_button);
		}

		private async void delete_task(object sender, EventArgs e)
		{
			await App.database.delete_task_async(task_);
			await Navigation.PopAsync();
		}
	}
}
