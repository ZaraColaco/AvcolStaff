using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Models
{
    public class Staff
    {
        public int RegistrationID {get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; } 
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
