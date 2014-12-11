using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportner.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
