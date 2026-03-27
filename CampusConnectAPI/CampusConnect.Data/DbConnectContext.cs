using CampusConnect.Model;
using Microsoft.EntityFrameworkCore;


namespace CampusConnect.Data
{
    public class DbConnectContext : DbContext
    {
        public DbConnectContext(DbContextOptions<DbConnectContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }

    }
}