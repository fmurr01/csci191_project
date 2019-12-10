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
        public SaveImage(string name, string timestamp, string coordinates, MediaFile photo)
        {
            InitializeComponent();
            imageIcon.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            imageName_label.Text = name ;
            timestamp_label.Text = timestamp;
            location_label.Text = coordinates;
            category_label.Text = "Selfie";
            directory = name + ".jpg";;

        }

        public String directory;

        private void ConfirmSave_button_Clicked(object sender, EventArgs e)
        {
            SaveImageViewModel.SaveImage(imageName_label.Text, timestamp_label.Text, location_label.Text, category_label.Text, directory, 0);
            this.Navigation.PopAsync();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            
            string tmp = category_label.Text;
            category_label.Text = new PicViewModel().SwipeCat(e, tmp);

        }


    }
}