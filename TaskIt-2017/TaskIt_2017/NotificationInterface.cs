using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIt_2017
{
    public interface NotificationInterface
    {
        void Notify(TaskItTask task);
        void NotifyMessage(string title, string message);
    }
}
