using System;
using Xamarin.Forms;

namespace TaskIt_2017
{
	public class TaskItTaskEntries
	{
		public Entry Name { get; }
		public Editor Description { get; }
		public DatePicker DueDate { get; }
		public TimePicker DueTime { get; }

		public TaskItTaskEntries()
		{
			DueDate = MakeDueDate();
			DueTime = MakeDueTime();
			Name = MakeEntry("Task Name");
			Description = new Editor();
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
				Time = DateTime.Now.TimeOfDay,
			};
		}

		private Entry MakeEntry(string placeholder)
		{
			return new Entry
			{
				Placeholder = placeholder
			};
		}

	}
}