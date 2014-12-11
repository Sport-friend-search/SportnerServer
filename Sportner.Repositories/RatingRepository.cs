using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Repositories
{

    public interface IRatingRepository
    {
        List<Rating> GetAll();
        List<Rating> GetByUser(int id);
        void Delete(int id);
        void Update(Rating updatedRating);
        void Insert(Rating rating);
    }

    public class RatingRepository : IRatingRepository
    {

        public List<Rating> GetAll()
        {
            List<Rating> ratings;
            using (SportnerContext db = new SportnerContext())
            {
                ratings = db.Ratings.ToList();
            }

            return ratings;
        }

        public List<Rating> GetByUser(int userId)
        {
            List<Rating> ratings;
            using (SportnerContext db = new SportnerContext())
            {
                ratings = db.Ratings.Where(rating => rating.UserId == userId).ToList();
            }

            return ratings;
        }

        public void Delete(int id)
        {
            using (SportnerContext db = new SportnerContext())
            {
                Rating ratingToRemove = db.Ratings.Find(id);

                if (ratingToRemove != null)
                {
                    db.Ratings.Remove(ratingToRemove);
                    db.SaveChanges();
                }
            }
        }

        public void Insert(Rating rating)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
            }
        }

        public void Update(Rating updatedRating)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Ratings.Attach(updatedRating);

                db.Entry(updatedRating).State = EntityState.Modified;
                db.SaveChanges();
            }
        }       
    }
}
