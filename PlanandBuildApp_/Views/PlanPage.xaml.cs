using PlanandBuildApp_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanandBuildApp_.Models;
using PlanandBuildApp_.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanandBuildApp_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanPage : TabbedPage
    {
        public PlanPage()
        { 
            InitializeComponent();
            //BindingContext = new PlanViewModel();
        }

        public async void Edit_Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var projectitem = button.BindingContext;
            var project = projectitem as Projects;
            if (project == null) return;

            await Navigation.PushAsync(new ProjectEdit(project));
            Project_List.SelectedItem = null;
        }

        private async void Project_List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var projectdetails = e.Item as Projects;
            await Navigation.PushAsync(new ProjectDetails(projectdetails.Project_Name, projectdetails.Tools, projectdetails.Steps));
        }
    }
}