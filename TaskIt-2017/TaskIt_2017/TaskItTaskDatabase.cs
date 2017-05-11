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

        public Task<List<TaskItTask>> GetTasksAsync()
        {
            return database.Table<TaskItTask>().ToListAsync();
        }

		public Task<List<TaskItTask>> GetTasksBySearch(string i)
        {
            return database.QueryAsync<TaskItTask>("SELECT * FROM [TaskItTask] WHERE [name] = "+i);
        } 

		public Task<List<TaskItTask>> GetTasksNotDoneAsync()
        {
            return database.QueryAsync<TaskItTask>("SELECT * FROM [TaskItTask] WHERE [complete] = 0");
        }

		public Task<TaskItTask> GetTaskAsync(int ID)
        {
            return database.Table<TaskItTask>().Where(i => i.Id == ID).FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(TaskItTask task)
        {
            if (task.Id != 0)
            {
                return database.UpdateAsync(task);
            }
            else
            {
                return database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(TaskItTask task)
        {
            return database.DeleteAsync(task);
        }

    }
}
