using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.WEB.Models;

namespace PruebaTecnica.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations go here...
            SeedRolesUsers(modelBuilder);
        }

        private static void SeedRolesUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Cliente", NormalizedName = "CLIENTE" },
                new IdentityRole { Id = "3", Name = "Empleado", NormalizedName = "EMPLEADO" }
            );
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                UserName = "admin@admin.com", // Change the username as needed
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = false
            };

            var password = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "Pa$$w0rd"); // Change the password as needed
            adminUser.PasswordHash = password;

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" } // Assign the "Admin" role to the admin user
            );
        }
    }
}
