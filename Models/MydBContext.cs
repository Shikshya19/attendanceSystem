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
    }
}
