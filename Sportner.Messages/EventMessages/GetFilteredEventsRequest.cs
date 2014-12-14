using System;

namespace Sportner.Messages.EventMessages
{
    public class GetFilteredEventsRequest
    {
        public string City { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? UserId { get; set; }

        public int? SportId { get; set; }
    }
}
