using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCapture.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public string Name { get; set; }
        public DateTime Attendance_Date { get; set; }
        public Boolean Attendance_status { get; set; }
        
        public Users Users { get; set; }
    }
}
