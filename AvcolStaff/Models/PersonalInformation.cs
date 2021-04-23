using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using AvcolStaff.Utilities;
using Microsoft.AspNetCore.Mvc;
using AvcolStaff.Pages.StaffS;
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
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "This field cannot be left empty")]
        public string Address { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(10, ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Emergency Contact #")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Phone]
        [StringLength(10, ErrorMessage = "Invalid Phone number")]
        public string EmergencyContact { get; set; }
        [Display(Name = "Emergency Contact Relationship")]
        [StringLength(56, ErrorMessage = "Invalid. Please enter a valid relationship e.g Friend, Brother etc.")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        public string EcRelaitonship { get; set; }
        [Display(Name = "Citizen Status")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        public string CitizenStatus { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(56, ErrorMessage = "The longest name of a country in the world is 56 charcters long ")]
        [Display(Name = "Ethnicity")]
        public string Ethnicity { get; set; }
        [Display(Name = "Email Address")]
        //[Required(ErrorMessage = "This field cannot be left empty")]
        [EmailAddress]
        public string EmailAddress { get; set; }


        public Staff Staff { get; set; }
    }

}
