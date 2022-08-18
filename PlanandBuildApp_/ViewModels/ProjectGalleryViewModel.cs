using PlanandBuildApp_.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using PlanandBuildApp_.Views;

namespace PlanandBuildApp_.ViewModels
{
    public class ProjectGalleryViewModel : BaseViewModel
    {
        public string Image_link { get; set; }

        private ObservableCollection<Gallery> _gallery;
        public ObservableCollection<Gallery> Gallery_carousel
        {
            get { return _gallery; }
            set
            {
                _gallery = value;
                OnPropertyChanged();
                
            }
        }
       

        public ProjectGalleryViewModel()
        {
            Gallery_carousel = new ObservableCollection<Gallery>
            {
                new Gallery{Image_link = "fences.jpg"},

                new Gallery{Image_link = "garden.jpg"},

                new Gallery{Image_link = "Shed.jpg"},

                new Gallery{Image_link = "stairs.jpg"}
            };
        }
    }
}
