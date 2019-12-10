using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using projectApp.Model;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.ObjectModel;
using projectApp.View;
using System.Runtime.CompilerServices;

namespace projectApp.ViewModel
{
    public class BrowseImagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public List<pic> pics { get; set; }

        ObservableCollection<pic> _pictures = new ObservableCollection<pic>();
        public List<pic> Pictures { get; set; }

        public BrowseImagesViewModel()
        {

            String fileName = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt";
            string text = File.ReadAllText(fileName);
            List<pic> pics = new List<pic>();
            pics = JsonConvert.DeserializeObject<List<pic>>(text);
            Pictures = pics;
            //     Pictures;
            //     Images = pics;
        }

        
            public List<pic> Sorter(bool time, bool dist, bool cat)
        {
            String fileName = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt";
            string text = File.ReadAllText(fileName);
            List<pic> pics = new List<pic>();
            pics = JsonConvert.DeserializeObject<List<pic>>(text);
            if (time)
            {
                var orderByTime = from p in pics
                                  orderby p.TimeStamp descending
                                  select p;

                Pictures = orderByTime.ToList();
                return Pictures;
            }
            else if(dist)
            {
                var orderByDistance = from p in pics
                                  orderby p.Rating descending
                                  select p;
                Pictures = orderByDistance.ToList();
                return Pictures;
            }
            else if (cat)
            {
                var orderByCat = from p in pics
                                  orderby p.Category descending
                                  select p;
                Pictures = orderByCat.ToList();
                return Pictures;
            }
            else {
                return pics;
                    }
        }

        
    }
}
