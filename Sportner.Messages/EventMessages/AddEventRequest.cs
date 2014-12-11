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
    [DataContract]
    public class AddEventRequest
    {
        [DataMember]
        public EventDto Event { get; set; }
    }
}
