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
			date_created = DateTime.Now;
		}

		public List<Label> get_display_labels()
		{
			var displays = new List<Label>();

			displays.Add(make_bold_label("Name"));
			displays.Add(make_label(name));

			displays.Add(make_bold_label("Description"));
			displays.Add(make_label(description));

			displays.Add(make_bold_label("Date Created"));
            displays.Add(make_label(get_date_string(date_created)));

            if (date_due != DateTime.MinValue)
			{
				displays.Add(make_bold_label("Date Due"));
				displays.Add(make_label(get_date_string(date_due)));
			}

			return displays;
		}

        private string get_date_string(DateTime date)
        {
            string day = date.Day.ToString();
            string year = (date.Year != DateTime.Now.Year) ? ", " + date.Year.ToString() : "";
            string month = CultureInfo.CurrentCulture.
                            DateTimeFormat.GetMonthName(date.Month);
            string date_string = month + " " + day + year;

            string hour = date.Hour.ToString();
            string minute = date.Minute >= 10 ? date.Minute.ToString() : "0" + date.Minute.ToString();
            string time = hour + ":" + minute;

            return time + " " + date_string;
        }

		private Label make_bold_label(string text)
		{
			return new Label { Text = text, FontAttributes = FontAttributes.Bold };
		}

		private Label make_label(string text)
		{
			return new Label { Text = text };
		}

		private KeyValuePair<string, string> make_kvp_s(string key, string value)
		{
			return new KeyValuePair<string,string>(key,value);
		}

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool complete { get; set; }
        public DateTime date_created { get; }
        public DateTime date_due { get; set; }

    }
}
