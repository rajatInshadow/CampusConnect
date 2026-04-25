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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasConversion<string>();  // 🔥 CRITICAL FIX
        }

    }
}