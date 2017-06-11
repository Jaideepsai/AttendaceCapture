using AttendanceCapture.Models;
using System;
using System.Linq;

namespace AttendanceCapture.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AttendanceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var Users = new Users[]
            {
            new Users{Name="Carson",DOB=DateTime.Parse("2005-09-01"),UnivId="U123001"},
            new Users{Name="Meredith",DOB=DateTime.Parse("2005-09-26"),UnivId="U123002"},
            new Users{Name="Arturo",DOB=DateTime.Parse("1995-01-11"),UnivId="U123008"},
            new Users{Name="Gytis",DOB=DateTime.Parse("1992-09-30"),UnivId="U123019"},
            new Users{Name="Yan",DOB=DateTime.Parse("1996-10-01"),UnivId="U123029"},
            new Users{Name="Peggy",DOB=DateTime.Parse("2001-12-31"),UnivId="U123012"},
            new Users{Name="Laura",DOB=DateTime.Parse("2005-09-01"),UnivId="U123068"},
            new Users{Name="Nino",DOB=DateTime.Parse("2005-09-01"),UnivId="U123098"}
            };
            foreach (Users s in Users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var Attendance = new Attendance[]
            {
            new Attendance{Name="Carson",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Meredith",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Arturo",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Gytis",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Yan",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=false},
            new Attendance{Name="Peggy",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Laura",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true},
            new Attendance{Name="Nino",Attendance_Date=DateTime.Parse("2005-09-01"),Attendance_status=true}
            };
            foreach (Attendance c in Attendance)
            {
                context.Attendance.Add(c);
            }
            context.SaveChanges();
            
        }
    }
}