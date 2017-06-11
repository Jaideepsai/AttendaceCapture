using AttendanceCapture.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceCapture.Data
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

    }
}
