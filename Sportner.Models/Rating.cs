using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportner.Models
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AssessorId { get; set; }
        public User Assessor { get; set; }

    }
}
