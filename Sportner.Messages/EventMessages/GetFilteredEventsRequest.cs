using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Messages.EventMessages
{
    [DataContract]
    public class GetFilteredEventsRequest
    {
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public DateTime? StartTime { get; set; }

        [DataMember]
        public DateTime? EndTime { get; set; }

        [DataMember]
        public int? UserId { get; set; }

        [DataMember]
        public int? SportId { get; set; }
    }
}
