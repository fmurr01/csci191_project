using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using projectApp.Model;
using projectApp.Service;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;


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

            String fileName = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt";

            string text = File.ReadAllText(fileName);
            List<pic> pics = new List<pic>();
            pics = JsonConvert.DeserializeObject<List<pic>>(text);
            Images = pics;
     
        }

        
    }
}
