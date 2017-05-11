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
		private ListView tasks;


		public TaskListPage()
		{
			InitializeComponent();

			tasks = MakeTasks();

			Content = MakeTasksListLayout();
		}

		protected override async void OnAppearing()
		{
			tasks.ItemsSource = await App.Database.GetTasksAsync();
		}


		// Creates the layout for the page
		// Includes: SearchBar, ListView for tasks, Button for adding tasks
		private StackLayout MakeTasksListLayout()
		{
			return new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Children =
				{
					MakeSearchBar(),
					tasks,
					MakeAddTaskButton(),
				}
			};
		}

		private SearchBar MakeSearchBar()
		{
			return new SearchBar
			{
				Placeholder = "Search for task...",
				SearchCommand = new Command(() =>
				{
					DisplayAlert("Howdy!", "You searched for something! WOW!", "WOW indeed!");

				}),

				// TODO: SearchCommand needs to eventually search for a task
			};
		}


		private ListView MakeTasks()
		{
			var tasksLV = new ListView();
			tasksLV.ItemTemplate = new DataTemplate(MakeTaskViewCell);
			tasksLV.ItemSelected += async (sender, e) =>
			{
				TaskItTask selectedTask = (TaskItTask)e.SelectedItem;
				await Navigation.PushAsync(new ViewTaskPage(selectedTask));
			};

			return tasksLV;
		}

		private ViewCell MakeTaskViewCell()
		{
			Label taskName = new Label();
			taskName.SetBinding(Label.TextProperty, "Name");
			taskName.HorizontalTextAlignment = TextAlignment.Center;

			return new ViewCell { View = new ContentView { Content = taskName } };
		}

		private Button MakeAddTaskButton()
		{
			Button addTaskButton = new Button
			{
				Text = "Add Task",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};
			addTaskButton.Clicked += AddTaskButtonClicked;
			return addTaskButton;
		}

		private async void AddTaskButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MakeTaskPage());
		}

	}
}
