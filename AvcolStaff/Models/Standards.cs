using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Standards
    {
        [Key]
        [Display(Name = "Subject")]
        public int SubjectsID { get; set; }//this should be the subject name
        [Range(0, 15, ErrorMessage = "Max Credits for a standard is 15")]
        public int Credits { get; set; }
        [Display(Name = "Standard Name")]
        [StringLength(60, ErrorMessage = "Standard name cannot be longer than 60 characters.")]
        public string StandardName { get; set; }
        [Display(Name = "Standard Code")]
        [DisplayFormat]
        public string StandardCode { get; set; }//As91883 Format
        public Subjects Subjects { get; set; }
        

    }
}
