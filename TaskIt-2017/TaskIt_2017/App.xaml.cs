using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public partial class App : Application
    {
        private readonly SQLiteAsyncConnection database_;

        //public static TaskItTaskDatabase database
        //{
        //    get
        //    {
        //        if (database_ == null)
        //        {
        //            database_ = new TaskItTaskDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TaskItSQLite.db3"));
        //        }
        //        return database;
        //    }
        //}

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TaskListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
