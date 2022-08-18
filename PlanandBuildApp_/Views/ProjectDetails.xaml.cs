using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanandBuildApp_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDetails : ContentPage
    {
        public ProjectDetails(string Project_Name, string Tools, string Steps)
        {
            InitializeComponent();

            ProjectName_.Text = Project_Name;
            Tools_.Text = Tools;
            Steps_.Text = Steps;
        }
    }
}