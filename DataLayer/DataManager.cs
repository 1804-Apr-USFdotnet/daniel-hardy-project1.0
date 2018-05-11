using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataManager
    {
        public IEnumerable<Resturant> GetResturants()
        {
            // This function takes a long time to run to completion.  Why?
            IEnumerable<Resturant> result;

            using (var dbcontext = new ResturantDBEntities())
            {
                int i = 0;
                var entities = dbcontext.Resturants.ToList();
                // due to Lazy loading, the Reviews seem to have to 
                // be explictly loaded ???
                foreach (var ent in dbcontext.Resturants)
                {
                    entities[i].Reviews = ent.Reviews.ToList();
                    i++;
                }
                result = entities.ToList();
            }
            return result.ToList();

        }
        public IEnumerable<Review> GetReviews()
        {
            IEnumerable<Review> reviewEntities;
            using (var dbcontext = new ResturantDBEntities())
            {
                reviewEntities = dbcontext.Reviews.ToList();
            }
            return reviewEntities.ToList();
        }

        public void Add(Resturant model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                dbcontext.Resturants.Add(model);
                dbcontext.SaveChanges();
            }
        }
        public void Add(Review model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                dbcontext.Reviews.Add(model);
                dbcontext.SaveChanges();
            }
        }

        public void Update(Resturant model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                foreach (var res in dbcontext.Resturants)
                {
                    if (res.rs_id == model.rs_id)
                    {
                        res.Name = model.Name;
                        res.Address = model.Address;
                        res.City = model.City;
                        res.State = model.State;
                        res.FoodType = model.FoodType;
                        break;
                    }
                }
                dbcontext.SaveChanges();
            }
        }
        public void Update(Review model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                foreach (var rev in dbcontext.Reviews)
                {
                    if (rev.rv_id == model.rv_id)
                    {
                        rev.Author = model.Author;
                        rev.Rating = model.Rating;
                        rev.Comment = model.Comment;
                    }
                }
                dbcontext.SaveChanges();
            }
        }

        public void Delete(Resturant model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                dbcontext.Resturants.Attach(model);
                dbcontext.Resturants.Remove(model);
                dbcontext.SaveChanges();
            }
        }
        public void Delete(Review model)
        {
            using (var dbcontext = new ResturantDBEntities())
            {
                dbcontext.Reviews.Attach(model);
                dbcontext.Reviews.Remove(model);
                dbcontext.SaveChanges();
            }
        }

        public override String ToString()
        {
            return "Farts";
        }
    }
}

