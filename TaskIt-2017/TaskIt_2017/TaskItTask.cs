using SQLite;
using System;
using System.Collections.Generic;

namespace TaskIt_2017
{
    public class TaskItTask
    {
        public TaskItTask() : this("Task", "Task description")
        {}
    
        public TaskItTask(string name) : this(name,name)
        {}

        public TaskItTask(string name, string description)
        {
            this.name = name;
            this.description = description;
            complete = false;
            date_created = DateTime.Now;
        }

        public List<KeyValuePair<string, string>> get_display_attributes()
        {
            var return_list = new List<KeyValuePair<string, string>>();

            return_list.Add(make_kvp("Name", name));
            return_list.Add(make_kvp("Description", description));
            return_list.Add(make_kvp("Date Created", date_created.ToString()));
            if (date_due != DateTime.MinValue)
            {
                return_list.Add(make_kvp("Date Due", date_due.ToString()));
            }

            return return_list;
        }

        private KeyValuePair<string,string> make_kvp(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public bool complete { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_due { get; set; }

    }
}
