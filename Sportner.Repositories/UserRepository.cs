using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Repositories
{

    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        void Delete(int id);
        void Update(User updateUser);
        void Insert(User user);
    }

    public class UserRepository : IUserRepository
    {

        public List<User> GetAll()
        {
            List<User> Users;
            using (SportnerContext db = new SportnerContext())
            {
                Users = db.Users.ToList();
            }

            return Users;
        }

        public User Get(int id)
        {
            User User;
            using (SportnerContext db = new SportnerContext())
            {
                User = db.Users.Find(id);
            }

            return User;
        }

        public void Delete(int id)
        {
            using (SportnerContext db = new SportnerContext())
            {
                User UserToRemove = db.Users.Find(id);

                if (UserToRemove != null)
                {
                    db.Users.Remove(UserToRemove);
                    db.SaveChanges();
                }
            }
        }

        public void Insert(User User)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Users.Add(User);
                db.SaveChanges();
            }
        }

        public void Update(User updatedUser)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Users.Attach(updatedUser);

                db.Entry(updatedUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }       
    }
}
