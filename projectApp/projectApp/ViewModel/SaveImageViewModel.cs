using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;
using Newtonsoft.Json;
using PCLStorage;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace projectApp.ViewModel
{
    class SaveImageViewModel
    {
        public SaveImageViewModel()
        {

        }
        public static void SaveImage(String Name, String TimeStamp, String Location, String Category)
        {
            String dir = "/storage/emulated/0/Android/data/com.companyname.projectapp/files/";
            pic savedPic = new pic();
            savedPic.Name = Name;
            savedPic.TimeStamp = TimeStamp;
            savedPic.Category = Category;
            savedPic.Coordinates = Location;
            savedPic.Directory = dir + "Pictures/cs191t/" + Name;
            string fileName = dir + "jsonFile.txt";
            List<pic> pics = new List<pic>();

            if (File.Exists(dir + "jsonFile.txt"))
            {
                string text = File.ReadAllText(fileName);
                try
                {                    
                    
                    pics = JsonConvert.DeserializeObject<List<pic>>(text);

                }
                catch (Exception e)
                {
                    Console.WriteLine("--------------Json did not save--------------");
                }
                pics.Add(savedPic);
                string json = JsonConvert.SerializeObject(pics);
                File.WriteAllText(fileName, json);
                
            }
            else
            {
              
                pics.Add(savedPic);
                string json = JsonConvert.SerializeObject(pics);
                File.WriteAllText(fileName, json);

            }
                      
        }

    }
}
