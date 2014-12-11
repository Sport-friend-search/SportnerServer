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
    public class GetEventRequest
    {
        [DataMember]
        public int EventId { get; set; }
    }
}
