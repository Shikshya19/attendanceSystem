using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        {

        }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<LogIn> LogIns { get; set; }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Group> Groups {get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
    }
}
