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
        [Required]
        [StringLength(35, ErrorMessage = "Invalid Department Name")]
        public string DepartmentName { get; set; }
    }
}
