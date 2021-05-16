using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class DepartmentSubjects
    {
        public int DepartmentSubjectsID { get; set; }
        [Display(Name = "Department Name")]
        [Required]
        public int DepartmentsID { get; set; }
        [Display(Name = "Subject Name")]
        public int? SubjectsID { get; set; }
        public Subjects Subjects { get; set; }
        public Departments Departments { get; set; }

    }
}
