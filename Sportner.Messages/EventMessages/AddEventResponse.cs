using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Messages.EventMessages
{
    public class AddEventResponse
    {
        [DataMember]
        public int EventId { get; set; }

        [DataMember]
        public List<string> Errors { get; set; } 
    }
}
