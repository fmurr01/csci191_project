using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using projectApp.ViewModel;

namespace projectApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class picView : ContentPage
    {
        public picView()
        {
            InitializeComponent();
        }

        void PicView_Clicked(object sender, System.EventArgs e)
        {

            ImageButton button = (ImageButton)sender;
            try
            {              
                SaveImageViewModel.SaveImage(imageName_entry.Text, timestamp_label.Text, coordinates_label.Text, category_label.Text, imageName_entry.Text, Convert.ToInt32(rating_label.Text));
            }
            catch (Exception exc)
            {
                Console.WriteLine("Did not save changes to image ----------" + exc);
            }
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            int i= Convert.ToInt32(rating_label.Text); ;
            rating_label.Text = new PicViewModel().SwipeRate(e, rating_label.Text, i);
            String tmp = category_label.Text;
            category_label.Text = new PicViewModel().SwipeCat(e, tmp);
        }
    }
}