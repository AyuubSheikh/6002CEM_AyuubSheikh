using System;
using System.Collections.Generic;
using System.Text;
using PlanandBuildApp_.Models;
using PlanandBuildApp_.Services;
using PlanandBuildApp_.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlanandBuildApp_.ViewModels
{
    public class PlanViewModel : BaseViewModel
    {
        private ProjectService services;
        public string Project_Name { get; set; }
        public string Tools { get; set; }
        public string Steps { get; set; }

        public Command Save_Project_Command { get; }

        private ObservableCollection<Projects> projects_ = new ObservableCollection<Projects>();
        public ObservableCollection<Projects> Projects_
        {
            get { return projects_; }
            set
            {
                projects_ = value;
                OnPropertyChanged();
            }
        }

        public PlanViewModel()
        {
            services = new ProjectService();
            Projects_ = services.getProject();
            Save_Project_Command = new Command(async () => await add_Projects_Async(Project_Name, Tools, Steps));
        }



        public async Task add_Projects_Async(string projectName, string tools, string steps)
        {
            if (string.IsNullOrEmpty(Project_Name) || string.IsNullOrEmpty(Tools) || string.IsNullOrEmpty(Steps))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Check all fields are filled in", "Ok");
            }
            else
            {
                await services.Add_Project(Project_Name, Tools, Steps);
                await Application.Current.MainPage.DisplayAlert("Success", "New Project Added", "Ok");
            }
        }

    }
}
