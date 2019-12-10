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
        private void time_button_Clicked (object sender, EventArgs e)
        {
            //  BrowseImagesViewModel.;
             
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(true,false,false);
        }

        private void rating_button_Clicked(object sender, EventArgs e)
        {
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(false, true, false);
        }

        private void category_button_Clicked(object sender, EventArgs e)
        {
            colView.ItemsSource = new BrowseImagesViewModel().Sorter(false, false, true);
        }
    }
}