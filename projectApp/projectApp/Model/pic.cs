using System;
using System.Collections.Generic;
using System.Text;

namespace projectApp.Model
{
    public class pic
    {
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Directory { get; set; }
        public string Coordinates { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
        public string OldName { get; set; }


        public pic()
        {
            Name = "";
            OldName = "";
            TimeStamp = "";
            Directory = "";
            Coordinates = "";
            Rating = 0;
            Category = "None";
        }

    }
        
}
