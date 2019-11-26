using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using projectApp.ViewModel;
using Plugin.Media.Abstractions;

namespace projectApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaptureImage : ContentPage
    {
        MediaFile photo;
        string timeStamp;
        Plugin.Media.Abstractions.Location imageLocation;
        public CaptureImage()
        {
            InitializeComponent();
            CaptureImage_Clicked();
            saveButton.IsVisible = false;
            discardButton.IsVisible = false;
        }
        public void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new View.SaveImage(photo, timeStamp, imageLocation));
        }
        private async void CaptureImage_Clicked()
        {
            await CrossMedia.Current.Initialize();

            //String storageDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            //Console.WriteLine(storageDir);

            timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            String imageFileName = "IMG_" + timeStamp + ".jpg";

            imageLocation = new Plugin.Media.Abstractions.Location();

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    imageLocation.Latitude = location.Latitude;
                    imageLocation.Longitude = location.Longitude;
                }
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


            photo = await CrossMedia.Current.TakePhotoAsync(
              new Plugin.Media.Abstractions.StoreCameraMediaOptions
              {
                  SaveToAlbum = true,
                  Directory = "cs191t",
                  Name = imageFileName,
                  Location = imageLocation,
                  SaveMetaData = true,
              });

            

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                discardButton.IsVisible = true;
                saveButton.IsVisible = true;
            }


            /*
            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }
            */
            /*if (file == null)
                return;
            await DisplayAlert("File Location", file.Path, "OK");
            */
        }
    }
}