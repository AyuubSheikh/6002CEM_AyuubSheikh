using PlanandBuildApp_.ViewModels;
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
    public partial class ProjectGallery : ContentPage
    {
        public ProjectGallery()
        {
            InitializeComponent();
            BindingContext = new ProjectGalleryViewModel();
        }
    }
}