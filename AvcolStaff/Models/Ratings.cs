using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AvcolStaff.Models
{
    public class Ratings
    {
        [Key]
        public int StaffID { get; set; }
        public int Experience_Years { get; set; }
        [Range(0,5)]
        public int ReviewStars { get; set; }
        public Staff Staff { get; set; }
    } 
}
