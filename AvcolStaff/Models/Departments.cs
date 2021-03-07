using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class Departments
    {
        public int DepartmentsID { get; set; }
        [Display(Name = "Department Name")]
        //[Required]
        public string DepartmentName { get; set; }//length less than 35
        [Display (Name= "Staff")]
        public int? StaffID { get; set; }
        public Staff Staff { get; set; }
    }
}
