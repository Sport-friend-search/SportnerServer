using System.Collections.Generic;
using Sportner.Dto;

namespace Sportner.Messages.EventMessages
{
    public class GetFilteredEventsResponse
    {
        public List<EventWithUserDto> EventsWithUsers { get; set; }

        public List<string> Errors { get; set; } 
    }
}
