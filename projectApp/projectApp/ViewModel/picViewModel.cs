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
    public class picViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public picViewModel(pic selectedPic)
        {
            Console.WriteLine("SWAG_----------------------------");
            var Name = selectedPic.Name;
            var Category = selectedPic.Category;
            var Rating = selectedPic.Rating;
            var TimeStamp = selectedPic.TimeStamp;
            var Coordinates = selectedPic.Coordinates;
        }


    }
}
