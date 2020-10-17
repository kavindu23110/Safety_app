using Safety_app.Data.DatabaseOperation;
using System;
using System.IO;
using Xamarin.Forms;

namespace Safety_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
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
        Environment.GetFolderPath(Environment.SpecialFolder.Personal), "sqlite.db3"));
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
