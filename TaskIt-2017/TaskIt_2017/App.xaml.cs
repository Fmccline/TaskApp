﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskIt_2017
{
    public partial class App : Application
    {
        static TaskItTaskDatabase database_;
        public static NotificationInterface NotificationHandler;
       
        public static TaskItTaskDatabase database
        {
            get
            {
                if (database_ == null)
                {
                    database_ = new TaskItTaskDatabase(DependencyService.Get<IFileHelper>().get_local_file_path("TaskItSQLite.db3"));
                }
                return database_;
            }
        }

        public static void InitNotification(NotificationInterface NI)
        {
            App.NotificationHandler = NI;
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TitlePage());
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
