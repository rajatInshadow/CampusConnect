using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusConnect.Model;
using Microsoft.EntityFrameworkCore;


namespace CampusConnect.Data
{
    public class DbConnectContext : DbContext
    {
        public DbConnectContext(DbContextOptions<DbConnectContext> options) : base(options) { }

            public DbSet<Student> Student { get; set; }

        }
    

}