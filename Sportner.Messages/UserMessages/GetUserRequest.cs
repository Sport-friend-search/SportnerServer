﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sportner.Models;

namespace Sportner.Messages.UserMessages
{
    [DataContract]
    public class GetUserRequest
    {
        [DataMember]
        public int UserId { get; set; }
    }
}
