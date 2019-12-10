using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using projectApp.Model;
using projectApp.ViewModel;
using Newtonsoft.Json;

namespace projectApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseImages : ContentPage
    {
        public BrowseImages()
        {
        InitializeComponent();
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // pass selected item to pic view
            var item = e.CurrentSelection.FirstOrDefault() as pic;
            var picViewPage = new picView();
            picViewPage.BindingContext = item;
            Navigation.PushAsync(picViewPage);
        }
        // Sort functionalities for every button. Refer to BrowseImagesViewModel().Sorter(...) for more information
        private void time_button_Clicked (object sender, EventArgs e)
        {
             
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(true,false,false, false, "");
        }

        private void distance_button_Clicked(object sender, EventArgs e)
        {
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(false, true, false, false, "");
        }

        private void category_button_Clicked(object sender, EventArgs e)
        {
            category_Button.Text = new BrowseImagesViewModel().PressCat(e, category_Button.Text);
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(false, false, true, false, category_Button.Text);
        }

        private void rating_button_Clicked(object sender, EventArgs e)
        {
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(false, false, false, true, "");
        }
    }
}