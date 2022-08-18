using PlanandBuildApp_.Services;
using PlanandBuildApp_.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanandBuildApp_
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
            //MainPage = new StoreLocatorPage();
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
