using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class Departments
    {
        public int DepartmentsID { get; set; }
        public string DepartmentName { get; set; }
        public string StaffId { get; set; }
        public Staff staff { get; set; }
    }
}
