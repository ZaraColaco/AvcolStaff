﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AvcolStaff.Models
{

    public class Sessions
    {
        [Key]
        [Display(Name = "Staff Name")]
        public int StaffID { get; set; }
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }//if the room is occupied on the same day at the same time i need a error message and room needs to be 2+ with letter and number
        [Display(Name = "Subject")]
        public int SubjectsID { get; set; }
        [Range(1,5,ErrorMessage = "Please choose a number between 1 and 5 (inclusive)")]
        public int Period { get; set; }
        [Required]
        public DayOfWeek Day { get; set; } 
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }//if period 1 then 9:15-10:10 period 2 10:15-11:10 period 3 11:35 - 12:30
        //period 4 1:20 - 2:15 period 5 2:20-3:15 autogenerated
        public Subjects Subjects { get; set; }
        public Staff Staff { get; set; }


    }
}
