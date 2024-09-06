using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Seeding roles(user, admin, superAdmin)
            var AdminRoleId = "8d0d3d54-aeb1-49cc-a19d-57d59caca7c6";
            var superAdminRoleId = "49cea7df-2775-4d10-b138-34ef4ebf6e07";
            var userRoleId = "b7c46f3b-1042-4507-8d69-4de4e55b507c";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = AdminRoleId,
                    ConcurrencyStamp = AdminRoleId
                },

                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp= userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "210394b6-3d35-4dce-b7b1-d8d4a1eac261";

            //Seed SuperUSer

            var superAdminUser = new IdentityUser
            {
                UserName = "super.admin@gmail.com",
                Email = "super.admin@gmail.com",
                NormalizedEmail = "super.admin@gmail.com".ToUpper(),
                NormalizedUserName = "super.admin@gmail.com".ToUpper(),
                Id = superAdminId,
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "super@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add all roles to super admin 
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
