using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TaskIt_2017
{
    public class TaskItTaskDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TaskItTaskDatabase (string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TaskItTask>().Wait();
        }

        public Task<List<TaskItTask>> get_tasks_async()
        {
            return database.Table<TaskItTask>().ToListAsync();
        }

        public Task<List<TaskItTask>> get_tasks_not_done_async()
        {
            return database.QueryAsync<TaskItTask>("SELECT * FROM [TaskItTask] WHERE [complete] = 0");
        }

        public Task<TaskItTask> get_task_async(int ID)
        {
            return database.Table<TaskItTask>().Where(i => i.id == ID).FirstOrDefaultAsync();
        }

        public Task<int> save_task_async(TaskItTask task)
        {
            if (task.id != 0)
            {
                return database.UpdateAsync(task);
            }
            else
            {
                return database.InsertAsync(task);
            }
        }

        public Task<int> delete_task_async(TaskItTask task)
        {
            return database.DeleteAsync(task);
        }

    }
}
