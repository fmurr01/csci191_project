using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;

namespace projectApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveImage : ContentPage
    {
        public SaveImage(MediaFile newImage, string timeStamp, Plugin.Media.Abstractions.Location loc)
        {
            InitializeComponent();
            imageIcon.Source = ImageSource.FromStream(() => { return newImage.GetStream(); });
            TimeStamp_Entry.Text = timeStamp;
            Location_Entry.Text = "(" + loc.Latitude.ToString() + " " + ", " + loc.Longitude.ToString() + ")";
            
        }
    }
}