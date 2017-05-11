using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace TaskIt_2017
{
	public class TaskItTask
	{
		public TaskItTask()
		{
			DateCreated = DateTime.Now;
		}

		public List<Label> GetDisplayLabels()
		{
			var displays = new List<Label>();

			displays.Add(MakeBoldLabel("Name"));
			displays.Add(MakeLabel(Name));

			displays.Add(MakeBoldLabel("Description"));
			displays.Add(MakeLabel(Description));

			displays.Add(MakeBoldLabel("Date Created"));
            displays.Add(MakeLabel(DateTimeToString(DateCreated)));

            if (DueDate != DateTime.MinValue)
			{
				displays.Add(MakeBoldLabel("Date Due"));
				displays.Add(MakeLabel(DateTimeToString(DueDate)));
			}

			return displays;
		}

        private string DateTimeToString(DateTime date)
        {
            string day = date.Day.ToString();
            string year = (date.Year != DateTime.Now.Year) ? ", " + date.Year.ToString() : "";
            string month = CultureInfo.CurrentCulture.
                            DateTimeFormat.GetMonthName(date.Month);
			string dateString = month + " " + day + year;

            string hour = date.Hour.ToString();
            string minute = date.Minute >= 10 ? date.Minute.ToString() : "0" + date.Minute.ToString();
            string time = hour + ":" + minute;

            return time + " " + dateString;
        }

		private Label MakeBoldLabel(string text)
		{
			return new Label { Text = text, FontAttributes = FontAttributes.Bold };
		}

		private Label MakeLabel(string text)
		{
			return new Label { Text = text };
		}


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public bool Complete { get; set; }
		public DateTime DateCreated { get; }
        public DateTime DueDate { get; set; }

    }
}
