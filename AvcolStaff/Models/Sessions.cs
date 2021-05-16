using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AvcolStaff.Models
{

    public class Sessions
    {
        public int SessionsID { get; set; }
        [Required]
        [Display(Name = "Staff Name")]
        public int StaffID { get; set; }
        [Display(Name = "Subject")]
        [Required]
        public int SubjectsID { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        [StringLength(3, ErrorMessage = "Invalid room number")]
        public string RoomNumber { get; set; }
        [Range(1,5,ErrorMessage = "Please choose a number between 1 and 5 (inclusive)")]
        [Required]
        public int Period { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [Required]
        public string Time { get; set; }
        public Subjects Subjects { get; set; }
        public Staff Staff { get; set; }
    }
}
