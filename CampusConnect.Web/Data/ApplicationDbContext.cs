using CampusConnect.Web.Models.Entities;
using CampusConnect.Web.Models.NewFolder2;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Facility> Facilities { get; set; }
    }
}
