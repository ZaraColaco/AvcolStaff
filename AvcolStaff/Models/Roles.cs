using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AvcolStaff.Models
{
    public class Roles
    {
        [Key]
        public int StaffID {get; set;}
        public string Role {get; set;}
        public Staff Staff {get; set;}
    }
}
