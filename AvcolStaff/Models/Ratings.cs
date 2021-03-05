using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AvcolStaff.Models;

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

    /*
        [Key]
        public int StaffID { get; set; }
        
        public Staff Staff { get; set; }
    [Display(Name = "Experience(Years)")]
        public int Experience_Years { get; set; }//<=45
        [Range(0,5)]
        [Display(Name = "Star Reviews")]
        public int ReviewStars { get; set; }//like the grades in the tutorial do 1-5*/


