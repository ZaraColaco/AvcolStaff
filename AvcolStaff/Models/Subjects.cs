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
        [Required]
        [StringLength(5, ErrorMessage = "Invalid Subject Name. Length cannot be longer than 5 characters e.g 12MAT, 13BIO")]
        public string SubjectName { get; set; }
        //public ICollection<Sessions> Sessions { get; set; }
        [Display(Name = "Department Name")]
        public int DepartmentsID { get; set; }
        public Departments Departments { get; set; }

        //public ICollection<Departments> Departments { get; set; }      
    }
}
