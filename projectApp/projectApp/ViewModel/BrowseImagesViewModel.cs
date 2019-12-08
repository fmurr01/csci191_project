using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;
using projectApp.Service;

namespace projectApp.ViewModel
{
    public class BrowseImagesViewModel
    {
        public List<Image> Images { get; set; }

        public BrowseImagesViewModel()
        {
            Images = new ImageService().GetImageList();
        }
    }
}
