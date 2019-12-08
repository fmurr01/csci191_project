using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using projectApp.Model;
using projectApp.Service;
using Xamarin.Forms;

namespace projectApp.ViewModel
{
    public class BrowseImagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<pic> Images { get; set; }

        public BrowseImagesViewModel()
        {
            Images = new ImageService().GetImageList();
        }

        
    }
}
