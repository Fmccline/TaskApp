using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public bool complete { get; set; }
    }
}
