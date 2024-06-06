using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;

namespace MotorMenezes.Infra.Data.Context
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public DbSet<IdentityRole> AspNetRoles { get; set; }
        public DbSet<IdentityUserRole<string>> AspNetUserRoles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Motorcycle> Motorcycle { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<CNHType> CNHType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.CNHNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.CNPJ).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Faz log das consultas no Banco
            //optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
