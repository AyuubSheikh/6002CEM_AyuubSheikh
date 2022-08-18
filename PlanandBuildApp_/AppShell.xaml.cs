using PlanandBuildApp_.ViewModels;
using PlanandBuildApp_.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlanandBuildApp_
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(PlanPage), typeof(PlanPage));
            Routing.RegisterRoute(nameof(ProjectGallery), typeof(ProjectGallery));
            Routing.RegisterRoute(nameof(StoreLocatorPage), typeof(StoreLocatorPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
