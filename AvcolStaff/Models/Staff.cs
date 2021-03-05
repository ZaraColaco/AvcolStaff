using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolStaff.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "First name cannot be longer than 35 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "Last name cannot be longer than 35 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(3, ErrorMessage = "Teacher code must be exactly 3 characters long.")]//need to validate this
        [Display(Name = "Teacher Code")]
        public string TeacherCode { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[date]//need to validate the date 1985 is the earliest
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        //public int RatingID;        
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public Rating Rating { get; set; }
        public Sessions Sessions { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public ICollection<Departments> Departments { get; set; }


    }
}
