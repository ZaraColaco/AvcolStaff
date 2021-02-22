using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class Standards
    {
        public string StandardsID { get; set; }//Standards can belong to many teachers and many teachers can have the same calss 12mat but only on teacher code needs to link to subject/departments
        public int CreditsAvaliable { get; set; }
        public string StandardName { get; set; }
        public string CourseCode { get; set; }
        public string StaffID { get; set; }
        public string SubjectsID { get; set; }

    }
}
