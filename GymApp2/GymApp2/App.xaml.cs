using GymApp;
using GymApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new LoginView();
            string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new AppShell();
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
