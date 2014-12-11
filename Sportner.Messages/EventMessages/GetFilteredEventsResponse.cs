using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;
using Sportner.Dto;

namespace Sportner.Messages.EventMessages
{
    public class GetFilteredEventsResponse
    {
        [DataMember]
        public List<EventWithUserDto> EventsWithUsers { get; set; }

        [DataMember]
        public List<string> Errors { get; set; } 
    }
}
