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
        public SaveImage(string name, string timestamp, string coordinates, MediaFile photo)
        {
            InitializeComponent();
            BindingContext = vm;
            imageIcon.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            imageName_label.Text = name ;
            timestamp_label.Text = timestamp;
            location_label.Text = coordinates;
            directory = name + ".jpg";

        }

        public String directory;

        private void ConfirmSave_button_Clicked(object sender, EventArgs e)
        {
            SaveImageViewModel.SaveImage(imageName_label.Text, timestamp_label.Text, location_label.Text, category_label.Text, directory);
            this.Navigation.PopAsync();
        }
        // confirmsave button here
        // if back button then delete the picture photo.Delete(path)
        // otherwise ADD to json file

    }
}