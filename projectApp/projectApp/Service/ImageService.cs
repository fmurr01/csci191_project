using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;
using projectApp.Service;
using Plugin.Media;
using Plugin.Media.Abstractions;
//using Plugin.Media;
//using Xamarin.Essentials;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;
using PCLStorage;
//using System.IO;

namespace projectApp.Service
{
    public class ImageService
    {

        public List<Model.pic> GetImageList()
        {
            //     /data/user/0/com.companyname.projectapp/files/Pictures/cs191t
            String storageLocation = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/Pictures/cs191t/";
            //tester();
            return new List<Model.pic>()
            {
                new Model.pic() { Name = "Swag", Coordinates = "310951395739758", Directory= storageLocation + "IMG_2019-12-08 215906.jpg", Rating=30, TimeStamp="63464364436", },
                new Model.pic() { Name = "SWUGG", Coordinates = "42424", Directory="camera.png", Rating=100, TimeStamp="53545", },
                new Model.pic() { Name = "Swagger", Coordinates = "444643634346", Directory="browse2.png", Rating=90, TimeStamp="46743986987", }
                
            };
        async void tester()
            {
                //   CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { 

                //   });  /storage/emulated/0/Android/data/com.companyname.projectapp/files/Pictures/cs191t/IMG_2019-12-08 215906.jpg
                IFolder folderpath = FileSystem.Current.LocalStorage; //+ "/Pictures/cs191t/IMG_2019-12-08 190835.jpg";
                Console.WriteLine("......------------------------------------------------------" + folderpath.CreateFolderAsync("swag", CreationCollisionOption.ReplaceExisting));
               // ExistenceCheckResult folderexist = await folderpath.CheckExistsAsync("Pictures");
               // Console.WriteLine("......------------------------------------------------------" + folderexist);
            }
        }
    }
}
