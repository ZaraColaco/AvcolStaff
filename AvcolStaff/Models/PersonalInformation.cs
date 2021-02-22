using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class PersonalInformation
    {
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int IrdNumber { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int EmergencyContact { get; set; }
        public string EcRelaitonship { get; set; }
        public string CitizenStatus { get; set; }
        public string BirthPlace { get; set; }
        public string EmailAddress { get; set; }
        public int SalaryID { get; set; }
        public int BankAccount { get; set; }
        public int StaffID { get; set; }

    }
}
