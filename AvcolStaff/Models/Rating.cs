using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Rating
    {
        [Key]
        [Display(Name = "Staff Name")]
        public int StaffID { get; set; }
        [Display(Name = "Star Ratings")]
        [Required]
        [Range(0, 5)]
        public int ReviewStars { get; set; }
        public Staff Staff { get; set; }

    }
}
