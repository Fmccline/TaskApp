using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIt
{
    public class TaskItTask
    {
        public TaskItTask(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public TaskItTask(string name)
        {
            this.name = name;
            description = name;
        }

        public string name { get; private set; }
        public string description { get; private set; }
    }
}
