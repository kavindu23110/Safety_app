using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Safety_app.Services;
using Safety_app.Views;
using Safety_app.Data;
using System.IO;
using Safety_app.Data.DatabaseOperation;
using Safety_app.Models;
using Safety_app.Helpers;

namespace Safety_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
        }
  

        static DataContext database;

        public static DataContext Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataContext(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Personal),"sqlite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
