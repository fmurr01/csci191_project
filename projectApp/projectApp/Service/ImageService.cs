using System;
using System.Collections.Generic;
using System.Text;
using projectApp.Model;

namespace projectApp.Service
{
    public class ImageService
    {
        public List<Image> GetImageList()
        {
            return new List<Image>()
            {
                new Image() {Name = "Swag", Coordinates = "310951395739758", Directory="browse1.png"},
                new Image() {Name = "Swagger", Coordinates = "444643634346", Directory="browse2.png"}
            };
        }
    }
}
