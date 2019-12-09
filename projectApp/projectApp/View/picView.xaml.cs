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
              //  Navigation.PushAsync(vm.MainPage_NextPage(button.ClassId));
            }
            catch (Exception exc)
            {
                Console.WriteLine("View change did not work out ----------" + exc);
            }
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {


            int i= System.Convert.ToInt32(rat.Text); ;
            rat.Text = new PicViewModel().SwipeRate(e, rat.Text, i);
            String tmp = cat.Text;
            cat.Text = new PicViewModel().SwipeCat(e, tmp);
            // rat.Text = $"{e.Direction.ToString()}";
        }
    }
}