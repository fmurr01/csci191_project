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
using Xamarin.Essentials;

namespace projectApp.ViewModel
{
    public class BrowseImagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Location loc { get; set; }
        public List<pic> pics { get; set; }

        ObservableCollection<pic> _pictures = new ObservableCollection<pic>();
        public List<pic> Pictures { get; set; }

        public BrowseImagesViewModel()
        {
            String fileName = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt";
            string text = File.ReadAllText(fileName);
            List<pic> pics = new List<pic>();
            pics = JsonConvert.DeserializeObject<List<pic>>(text);
            GetLocation(pics);
            Pictures = pics;
            //     Pictures;
            //     Images = pics;
        }

        public async void GetLocation(List<pic> pics)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                Location loc = new Location();
                loc = await Geolocation.GetLocationAsync(request);
                Console.WriteLine($"Latitude: {loc.Latitude}, Longitude: {loc.Longitude}, Altitude: {loc.Altitude}");
                foreach(pic p in pics){
                    p.Distance = GetDistance(p,loc);
                }
                string json = JsonConvert.SerializeObject(pics);
                File.WriteAllText("/storage/emulated/0/Android/data/com.companyname.projectapp/files/jsonFile.txt", json);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        public Double GetDistance(pic p, Location location)
        {
            string[] tmp = p.Coordinates.Split(',');
            Double picLatitude = Convert.ToDouble(tmp[0].Substring(1) + "," + tmp[1]);
            Double picLongitude = Convert.ToDouble(tmp[2] + "," + tmp[3].Substring(0, tmp[3].Length - 1));
            Location picLocation = new Location(picLatitude, picLongitude);
            Double Distance = Location.CalculateDistance(picLocation, location, DistanceUnits.Kilometers);
            return Distance;
        }

        public List<pic> Sorter(bool time, bool dist, bool cat, bool rat)
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
                                      orderby p.Distance descending
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
            else if (rat)
            {
                var orderByDistance = from p in pics
                                      orderby p.Rating descending
                                      select p;
                Pictures = orderByDistance.Take(5).ToList();
                return Pictures;
            }
            else {
                return pics;
                    }
        }


        
    }
}
