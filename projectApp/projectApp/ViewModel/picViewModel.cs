using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using projectApp.Model;
using projectApp.View;
using Xamarin.Forms;

namespace projectApp.ViewModel
{
    public class PicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PicViewModel()
        {

        }

        public pic SelectedPic(pic selectedItem)
        { 
            return selectedItem;
        }

        public String SwipeRate(SwipedEventArgs e, String rat, int i)
        {
            
            if (e.Direction.ToString() == "Right")
            {
                i++;
                rat = i.ToString();
                return rat;
            }
            if (e.Direction.ToString() == "Left")
            {
                i--;
                rat = i.ToString();
                return rat;

            }
            return rat;
        }

        public String SwipeCat(SwipedEventArgs e, String orig)
        {
            string[] Categories = new string[5] { "Selfie", "Nature", "City", "Random", "Swag" };
           
            int i = 0;
            
            if (!orig.Equals("") || !orig.Equals("CATEGORY"))
            {
                i = Array.IndexOf(Categories, orig);
            }

            if (e.Direction.ToString() == "Up")
            {
                if (i < 4)
                {
                    i++;
                }
                String tmp = Categories[i];       
                return tmp;
            }
            else if (e.Direction.ToString() == "Down")
            {
                if (i > 0)
                {
                    i--;
                }
                String tmp = Categories[i];
            
                return tmp;

            }
            return orig;
        }
    }
}
