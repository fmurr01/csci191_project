using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;
using projectApp.Service;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Xamarin.Essentials;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;

namespace projectApp.Service
{
    public class ImageService
    {

        //not used
        public async void PicPicker() {
            var Photo = await CrossMedia.Current.PickPhotoAsync(
                 new Plugin.Media.Abstractions.PickMediaOptions
                 {
                     CustomPhotoSize = 90//Resize to 90% of original
                 });
            var dir = Photo.Path;
        }

        public List<Model.pic> GetImageList()
        {
  
            return new List<Model.pic>()
            {
                new Model.pic() { Name = "Swag", Coordinates = "310951395739758", Directory="browse1.png", Rating=30, TimeStamp="63464364436", },
                new Model.pic() { Name = "SWUGG", Coordinates = "42424", Directory="camera.png", Rating=100, TimeStamp="53545", },
                new Model.pic() { Name = "Swagger", Coordinates = "444643634346", Directory="browse2.png", Rating=90, TimeStamp="46743986987", }
            };
        }
    }
}
