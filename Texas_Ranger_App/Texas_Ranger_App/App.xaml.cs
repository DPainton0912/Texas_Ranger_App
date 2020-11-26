using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Texas_Ranger_App.Data;

namespace Texas_Ranger_App
{
    public partial class App : Application
    {
        static ReservationDatabase database;

        public static ReservationDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReservationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reservations.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainTabbedPage());
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
