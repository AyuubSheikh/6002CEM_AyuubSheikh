using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanandBuildApp_.Services;
using PlanandBuildApp_.ViewModels;
using PlanandBuildApp_.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanandBuildApp_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectEdit : ContentPage
    {
        ProjectService services;
        public ProjectEdit(Projects project)
        {
            InitializeComponent();
            BindingContext = project;
            services = new ProjectService();
        }
        public async void Del_Button_Clicked(object sender, EventArgs e)
        {
            await services.Delete_Project(Project_Name.Text, Tools.Text, Steps.Text);
            await Application.Current.MainPage.DisplayAlert("Deleted", "Project Deleted", "Ok");
            await Navigation.PushAsync(new PlanPage());
        }
        public async void Up_Button_Clicked(object sender, EventArgs e)
        {
            //valuidation
            if (string.IsNullOrEmpty(Tools.Text) || string.IsNullOrEmpty(Steps.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Check all fields are filed in", "Ok");
            }
            else
            {
                await services.Update_Project(Project_Name.Text, Tools.Text, Steps.Text);
                await Application.Current.MainPage.DisplayAlert("Success", "Project Updated", "Ok");
                await Navigation.PushAsync(new PlanPage());
            }
        }

    }
}