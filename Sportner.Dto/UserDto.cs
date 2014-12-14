using System;
using System.Collections.Generic;

namespace Sportner.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public List<int> InterestedSportsIds { get; set; }
        public string PhotoURI { get; set; }
        public string Description { get; set; }
        public long? FacebookId { get; set; }
        public string FacebookToken { get; set; }
    }
}
