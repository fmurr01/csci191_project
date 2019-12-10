using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;
using Xamarin.Forms;

namespace projectApp.ViewModel
{
    class MainPageViewModel
    {
        //public string captureImage { get; }
        public string CameraPage { get; }
        public string BrowsePage { get; }
        public string RatePage { get; }
        public string LocationPage { get; }

        public MainPageViewModel()  // Image type from model 
        {
            CameraPage = "CameraButtonId";
            BrowsePage = "BrowseButtonId";
            RatePage = "RateButtonId";
            LocationPage = "LocationButtonId";
        }

        public Page MainPage_NextPage(string nextPageName)  
        {
            if (nextPageName == CameraPage)    
            {
                return new View.CaptureImage();
            }
            else if (nextPageName == BrowsePage)
            {
                return new View.BrowseImages();
            }
            else if(nextPageName == LocationPage)  
            {
                return new View.MapImages();
            }
            return null;
        }
    }
}
