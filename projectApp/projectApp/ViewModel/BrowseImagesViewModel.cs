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
using System.Linq;


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
            var orderByTime = from p in pics
                                     orderby p.TimeStamp descending
                                     select p;
            pics = orderByTime.ToList();
            Images = pics;
     
        }

        
    }
}
