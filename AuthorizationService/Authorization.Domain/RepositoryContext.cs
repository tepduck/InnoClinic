using Authorization.Domain.Configuration;
using Authorization.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Authorization.Domain
{
    public class RepositoryContext : IdentityDbContext<Account>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity => entity.ToTable(name: "Accounts"));
            modelBuilder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => 
                entity.ToTable(name: "AccountRoles"));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "AccountClaims"));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable(name: "AccountLogins"));
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable(name: "AccountTokens"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable(name: "RoleClaims"));


            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new ReceptionistConfiguration());
        }

        public DbSet<Account> Accounts { get; set; }
        //public DbSet<Appoitment> Appoitments { get; set;}
        public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Document> Documents { get; set; }
        //public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        //public DbSet<Photo> Photos { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        //public DbSet<Result> Results { get; set; }
        //public DbSet<Service> Services { get; set; }
        //public DbSet<ServiceCategory> ServiceCategories { get; set; }
        //public DbSet<Specialization> Specializations { get; set; }

    }
}