using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportner.Models
{
    public class SportnerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public SportnerContext() : base("SportnerContext")
        {
            this.Configuration.ProxyCreationEnabled = false; 
        }
    }
}
