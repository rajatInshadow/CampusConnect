using Microsoft.EntityFrameworkCore;
using CampusConnect.Models.Models.Entities;

namespace CampusConnect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<User>  Users { get; set; }
    }
}
