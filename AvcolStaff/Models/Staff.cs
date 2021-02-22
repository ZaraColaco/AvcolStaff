using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherCode { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

    }
}
