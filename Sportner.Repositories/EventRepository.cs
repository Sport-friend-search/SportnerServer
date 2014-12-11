using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Repositories
{

    public interface IEventRepository
    {
        List<Event> GetAll();
        Event Get(int id);
        void Delete(int id);
        void Update(Event updateUser);
        void Insert(Event user);
    }

    public class EventRepository : IEventRepository
    {

        public List<Event> GetAll()
        {
            List<Event> events;
            using (SportnerContext db = new SportnerContext())
            {
                events = db.Events.ToList();
            }

            return events;
        }

        public Event Get(int id)
        {
            Event Event;
            using (SportnerContext db = new SportnerContext())
            {
                Event = db.Events.Find(id);
            }

            return Event;
        }

        public void Delete(int id)
        {
            using (SportnerContext db = new SportnerContext())
            {
                Event EventToRemove = db.Events.Find(id);

                if (EventToRemove != null)
                {
                    db.Events.Remove(EventToRemove);
                    db.SaveChanges();
                }
            }
        }

        public void Insert(Event Event)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Events.Add(Event);
                db.SaveChanges();
            }
        }

        public void Update(Event updatedEvent)
        {
            using (SportnerContext db = new SportnerContext())
            {
                db.Events.Attach(updatedEvent);

                db.Entry(updatedEvent).State = EntityState.Modified;
                db.SaveChanges();
            }
        }       
    }
}
