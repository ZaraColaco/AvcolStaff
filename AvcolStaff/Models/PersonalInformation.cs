using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AvcolStaff.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AvcolStaff.Models
{
    public class PersonalInformation
    {
        [Key]
        [Display(Name = "Staff Name")]
        public int StaffID { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[date]//need to validate the date 1985 is the earliest
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }//has to be less than 80 years old

        [Required(ErrorMessage = "This field cannot be left empty")]
        public string Address { get; set; }//need some kind of validation
        [Phone]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        public string PhoneNumber { get; set; }//10 digits
        [Display(Name = "Emergency Contact #")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Phone]
        public string EmergencyContact { get; set; }//10 digits
        [Display(Name = "Emergency Contact Relationship")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        public string EcRelaitonship { get; set; }//need something
        [Display(Name = "NZ Citizen?")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        public string CitizenStatus { get; set; }// citzen or Non-citizen
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(56, ErrorMessage = "The longest name of a country in the world is 56 charcters long ")]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        [EmailAddress]
           //[Remote(action: "IsEmailInUse", controller: "Account")]
        //[ValidEmailDomain(allowedDomain: "avcol.school.nz", ErrorMessage = "Please ensure this is a valid Avcol adress")]
        public string EmailAddress { get; set; }//email format needs to contain one @ and end.com


        public Staff Staff { get; set; }
    }

}
