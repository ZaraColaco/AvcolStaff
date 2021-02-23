using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AvcolStaff.Models
{

    public class Sessions
    {
        [Key]
        public int StaffID { get; set; }
        public string RoomNumber { get; set; }
        public string SubjectsID { get; set; }
        public int Period { get; set; }
        public string day { get; set; }
        public DateTime Time { get; set; }
        public string StandardsID { get; set; }


    }
}
