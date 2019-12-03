using System;
using System.Collections.Generic;
using System.Text;

namespace projectApp.Model
{
    class Image
    {
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Directory { get; set; }
        public string Coordinates { get; set; }
        public int Rating { get; set; }
        public List<string> Category { get; set; }

        public Image()
        {
            Name = "";
            TimeStamp = "";
            Directory = "";
            Coordinates = "";
            Rating = 0;
            Category = new List<string>();
        }
    }
}
