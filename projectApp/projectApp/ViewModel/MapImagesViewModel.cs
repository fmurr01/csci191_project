﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using projectApp.Model;
namespace projectApp.ViewModel
{
    class MapImagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        ObservableCollection<string> _CategoryList;
        List<Model.pic> mapList { get; set; }
        public string _MapCategory;
        public string MapCategory
        {
            get { return _MapCategory; }
            set
            {
                _MapCategory = value;
                RaisePropertyChanged("MapCategory");
            }
        }
        public ObservableCollection<string> CategoryList
        {
            get { return _CategoryList; }
            set { _CategoryList = value; RaisePropertyChanged(); }
        }

        public MapImagesViewModel()
        {
            _CategoryList = new ObservableCollection<string>();
            _CategoryList.Add("Selfie");
            _CategoryList.Add("Nature");
            _CategoryList.Add("City");
            _CategoryList.Add("Random");
            _CategoryList.Add("Swag");
            mapList = new List<Model.pic>();

            DeserializeImageJson();
        }

        public List<pic> CreateMapList()   //filters mapList for pic category
        {
            List<Model.pic> tmp = new List<Model.pic>(mapList);
            var tempList = from p in mapList
                           where p.Category == _MapCategory
                           select p;
            tmp = tempList.ToList();
            return tmp;

        }

        public void DeserializeImageJson()
        {
            var jsonpath = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt";
            Console.WriteLine("JSONPATH: {0}", jsonpath);
            string jsonData = File.ReadAllText(jsonpath);

            if (jsonData != "")
            {
                mapList = JsonConvert.DeserializeObject<List<Model.pic>>(jsonData);
            }

        }
        public List<Model.pic> GetImagesToPin()
        {
            //Executes and returns CreateMapList();
            Console.WriteLine("MAPLIST: {0}", mapList.Count);
            return CreateMapList(); 
        }
    }
}