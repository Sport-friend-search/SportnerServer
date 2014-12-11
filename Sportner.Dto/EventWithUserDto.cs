using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Dto
{
    public class EventWithUserDto
    {
        public Event Event { get; set; }
        public User User { get; set; }
    }
}
