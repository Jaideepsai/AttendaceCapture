using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceCapture.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string UnivId { get; set; }

        [NotMapped]
        public Boolean Temporary_status{ get; set; }

        public ICollection<Attendance> Attendance { get; set; }


    }
}
