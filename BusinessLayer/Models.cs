using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
	    public int rv_id { get; set; }
	    public int rs_id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range( 1,5)]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
    }
    public class Resturant
    {
        public int rs_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
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
