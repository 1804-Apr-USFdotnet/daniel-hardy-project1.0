using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer
{
    public class ResturantRating
    {
        public int Rating { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }

        public ResturantRating()
        {

        }

        public ResturantRating(int r, string au, string com)
        {
            Rating = r;
            Author = au;
            Comments = com;
        }
    }
}
