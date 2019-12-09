using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            
            rat.Text = $"{e.Direction.ToString()}";
        }
    }
}