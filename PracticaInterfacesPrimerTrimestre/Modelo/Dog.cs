using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Modelo
{
    public class Dog
    {
        public string Name {  get; set; }
        public string Origin { get; set; }
        public DogImage Image { get; set; }

        public class DogImage
        {
            public string Url { get; set; }
        }
    }
}
