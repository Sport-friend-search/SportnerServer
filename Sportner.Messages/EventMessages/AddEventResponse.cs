using System.Collections.Generic;

namespace Sportner.Messages.EventMessages
{
    public class AddEventResponse
    {
        public int EventId { get; set; }

        public List<string> Errors { get; set; } 
    }
}
