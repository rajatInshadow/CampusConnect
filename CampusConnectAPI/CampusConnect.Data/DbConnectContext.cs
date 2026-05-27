using CampusConnect.Model;
using Microsoft.EntityFrameworkCore;


namespace CampusConnect.Data
{
    public class DbConnectContext : DbContext
    {
        public DbConnectContext(DbContextOptions<DbConnectContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Admission> Admission { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecord { get; set; }
        public DbSet<AttendanceSession> AttendanceSession { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasConversion<string>();  // 🔥 CRITICAL FIX
        }

    }
}