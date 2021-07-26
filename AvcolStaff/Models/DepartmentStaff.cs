using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class DepartmentStaff
    {
        public int DepartmentStaffID { get; set; }
        [Display(Name = "Staff Name")]
        [Required]
        public int StaffID { get; set; }
        [Display(Name = "Department")]
        [Required]
        public int DepartmentsID { get; set; }
        public Staff Staff { get; set; }
        public Departments Departments { get; set; }

    }
}
