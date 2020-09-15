using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using fmmApp.Services;
using fmmApp.Views;
using fmmApp.Views.Navigation;
using fmmApp.Views.Forms;
using fmmApp.Views.SponsorDetail;
using fmmApp.Views.Detail;

namespace fmmApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://";
        
        
        public App()
        {
            InitializeComponent();
            Startup.Init();
            MainPage = new AddDreamPage();
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
