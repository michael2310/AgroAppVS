using AgroApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
            //builder.Entity<UserModel>().HasData(new UserModel { Login = "admin", Name = "admin", Surname = "admin", Password = "admin" });

            //Wpis z polem
           // builder.Entity<FieldModel>()
             //   .HasMany(c => c.Entry)
               // .WithOne(e => e.Field)
                //.IsRequired();

            //Użytkownik z gospodarstwem



            builder.Entity<UserModel>().HasOne(user => user.OwnershipFarm)
                   .WithOne(farm => farm.FarmOwner)
                   .OnDelete(DeleteBehavior.Restrict);
                 
                   
            //     .HasForeignKey<FarmModel>(farm => farm.FarmOwnerId);
            // builder.Entity<FarmModel>()
            //     .HasMany(c => c.FarmOwner).WithOne(e => e.Farm)
            //    .IsRequired();
            //builder.Entity<UserModel>().HasOne(x => x.OwnershipFarm)
            //    .WithOne(farm => farm.FarmOwner);
               
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "2424ba03-fe48-427d-8feb-51cedaf5f3b9", Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "Administrator" },
                new IdentityRole() { Id = "43cf4e6b-a87d-43b7-8896-68f6fc9cc64f", Name = "Farmer", ConcurrencyStamp = "2", NormalizedName = "Farmer" },
                new IdentityRole() { Id = "f79e0432-f23c-4ec5-b7f2-8662f460659e", Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "Employee" }
                );
        }

        private void SeedUsers(ModelBuilder builder)
        {
            UserModel user = new UserModel()
            {
                Id = "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                UserName = "Admin",
                Name = "Admin",
                Surname = "Admin",
                Position = "Admin",
                Email = "admin@test.pl",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@TEST.PL",
                LockoutEnabled = false,
            };

            PasswordHasher<UserModel> passwordHasher = new PasswordHasher<UserModel>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Test1234!");
            

            builder.Entity<UserModel>().HasData(user);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "2424ba03-fe48-427d-8feb-51cedaf5f3b9", UserId = "7b6c29c2-68a5-41b2-99bb-bdffade561fa" }
                );
        }

        public DbSet<FarmModel> Farms { get; set; }

        public DbSet<FieldModel> Fields { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<EntryModel> Entries { get; set; }

        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<MachineServiceModel> Services { get; set; }
    }
}