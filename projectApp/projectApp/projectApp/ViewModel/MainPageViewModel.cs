using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;

namespace projectApp.ViewModel
{
    class MainPageViewModel
    {
        public string captureImage { get; }
        public MainPageViewModel(Image image)
        {
            captureImage = $"{image.Name}";
        }
    }
}
