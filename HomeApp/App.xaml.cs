using HomeApp.Pages;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HomeApp
{
    public partial class App : Application
    {
        public static HttpClient HttpClient { get; } = new HttpClient();
        public App()
        {

            InitializeComponent();

            MainPage = new LoginPage();
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
