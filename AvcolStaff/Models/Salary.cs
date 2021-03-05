using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Salary
    {
        public int SalaryID { get; set; }
        public int StaffID { get; set; }
        [Display(Name = "Salary Grade")]
        public string SalaryGradeName { get; set; }//How is this calculated relating the start and end range
        [Display(Name = "Start Range")]
        public decimal StartRange { get; set; }//how 
        [Display(Name = "End Range")]
        public decimal EndRange { get; set; }//how
        [Display(Name = " Actual Salary")]
        public decimal ActualSalary { get; set; }//52,000 - 100,000 for teachers 
        [Display(Name = "Moe Number")]
        [Required]
        public string MoeNumber { get; set; }//must be unique and 7 digits long
        
    }
}
