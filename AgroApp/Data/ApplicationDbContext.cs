using AgroApp.Models;
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


        public DbSet<FarmModel> Farms { get; set; }

        public DbSet<FieldModel> Fields { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<EntryModel> Entries { get; set; }

        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}