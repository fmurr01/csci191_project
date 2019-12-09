using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using projectApp.Model;
using projectApp.View;
using projectApp.Service;
using Xamarin.Forms;

namespace projectApp.ViewModel
{
    public class PicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PicViewModel()
        {

        }

        public pic selectedPic(pic selectedItem)
        { 
            return selectedItem;
        }

    }
}
