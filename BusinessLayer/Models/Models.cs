using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
	public int rv_id { get; set; }
	public int rs_id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
    public class Resturant
    {
        public int rs_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FoodType { get; set; }
        public List<Review> Reviews { get; set; }

        public Resturant()
        {
            Reviews = new List<Review>();
        }

        public double getAverageRating()
        {
            double x = 0;
            foreach (var r in Reviews)
            {
                x += r.Rating;
            }
            return (x / Reviews.Count);
        }
    }
}
