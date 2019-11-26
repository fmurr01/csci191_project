using System;
using System.Collections.Generic;
using System.Text;

namespace projectApp.Model
{
    class Image
    {
        public string Name { get; set; }
        public string Directory { get; set; }
        public string Geolocation { get; set; }
        public int Rating { get; set; }
        public List<string> Category { get; set; }
    }
}
