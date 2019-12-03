using Plugin.Media.Abstractions;
using projectApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveImage : ContentPage
    {
        SaveImageViewModel vm;
        Model.Image NewImage;
        public SaveImage(string name, string timestamp, string coordinates, MediaFile photo)
        {
            InitializeComponent();
            BindingContext = vm;
            imageIcon.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            imageName_label.Text = "IMG_" + (new Random()).Next().ToString();
            timestamp_label.Text = timestamp;
            location_label.Text = coordinates;
            
        }

        private void ConfirmSave_button_Clicked(object sender, EventArgs e)
        {
            //vm.SaveImageInfo()
        }
        // confirmsave button here
        // if back button then delete the picture photo.Delete(path)
        // otherwise ADD to json file

    }
}