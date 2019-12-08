using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using projectApp.Model;

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
            var item = e.CurrentSelection.FirstOrDefault() as pic;
            Console.WriteLine(item.Name);
            Navigation.PushAsync(new picView());
        }

    }
}