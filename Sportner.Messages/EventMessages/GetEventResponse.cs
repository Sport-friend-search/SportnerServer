using System.Collections.Generic;
using Sportner.Dto;

namespace Sportner.Messages.EventMessages
{
    public class GetEventResponse
    {
        public EventDto Event { get; set; }

        public List<string> Errors { get; set; } 
    }
}
