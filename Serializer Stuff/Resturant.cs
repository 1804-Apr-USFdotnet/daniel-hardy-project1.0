using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.Layer
{
    [XmlRoot("ArrayOfResturant")]
    public class MyList<Resturant> : List<Resturant>
    {
        public MyList() 
        {
            list = new List<Resturant>();
        }
        [XmlElement("Resturant")]
        public List<Resturant> list { get; set;}
    }
    public class Resturant
    {
       
        public string Name { get; set; }
        public string Location { get; set; }
        public string FoodType { get; set; }
        public List<ResturantRating> Ratings = new List<ResturantRating>();

        public Resturant()
        {
        }

        public float GetAverageRating()
        {
            int i = 0;
            foreach (var rnk in Ratings )
            {
                i += rnk.Rating;
            }

            return i / Ratings.Count;
        }

        
        public void AddRating(ResturantRating r)
        {
            
            Ratings.Add(r);
        }
        
    }
}
