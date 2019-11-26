using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using projectApp.Model;
using projectApp.ViewModel;

namespace projectApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        Model.Image _image;
        public MainPage()
        {
            InitializeComponent();
            _image = new Model.Image();
            _image.Name = "IMAGE1";

            vm = new ViewModel.MainPageViewModel(_image);
            BindingContext = vm;
        }
        void MainPage_Clicked(object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            if(button == CaptureButton)
            {
                Navigation.PushAsync(new View.CaptureImage());
            }
            else if(button == BrowseButton)
            {
                Navigation.PushAsync(new View.BrowseImages());
            }
            else if(button == RateButton)
            {
                Navigation.PushAsync(new View.RateImages());
            }
        }
    }
    
}
