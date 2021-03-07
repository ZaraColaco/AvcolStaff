using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Subjects
    {
        public int SubjectsID { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }//length less than 35
        [Display(Name = "Department")]
        public int DepartmentsID { get; set; }
        public Departments Departments { get; set; }
        public Standards Standards { get; set; }
        public Sessions Sessions { get; set; }
    }
}
