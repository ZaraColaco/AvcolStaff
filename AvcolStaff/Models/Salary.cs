using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class Salary
    {
        public int SalaryID { get; set; }
        public string StaffID { get; set; }
        public string SalaryGradeName { get; set; }//How is this calculated relating the start and end range
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public int ActualSalary { get; set; }
        public int MoeNumber { get; set; }
    }
}
