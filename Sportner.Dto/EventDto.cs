﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportner.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int SportId { get; set; }

        public int UserId { get; set; }
    }
}
