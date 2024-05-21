using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectTracker.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<ProjectTask>().Navigation(c => c.Project).AutoInclude();
            modelBuilder.Entity<Project>().Navigation(c => c.ProjectDetails).AutoInclude();
            base.OnModelCreating(modelBuilder);

            // Add Role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { 
                    Id= "AdminAdmin-a24d-4543-a6c6-9443d048cdb9",
                    Name = "Admin", 
                    NormalizedName = "ADMIN" 
                });

            
            // Add User
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "AAAAAAAA-a24d-4543-a6c6-9443d048cdb9",
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                SecurityStamp = string.Empty
            }); ;

           
            //Add User to Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "AdminAdmin-a24d-4543-a6c6-9443d048cdb9",
                UserId = "AAAAAAAA-a24d-4543-a6c6-9443d048cdb9"
            });


            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = "UserUser-a24d-4543-a6c6-9443d048cdb9",
                   Name = "User",
                   NormalizedName = "USER"
               });

            // Add User           
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "ZZZZZZZZ-a24d-4543-a6c6-9443d048cdb9",
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User123!"),
                SecurityStamp = string.Empty
            }); ;

            //Add User to Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "UserUser-a24d-4543-a6c6-9443d048cdb9",
                UserId = "ZZZZZZZZ-a24d-4543-a6c6-9443d048cdb9"
            });
        }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectDetails> ProjectDetails { get; set; }

        //public DbSet<User> Users { get; set; }

    }
}
