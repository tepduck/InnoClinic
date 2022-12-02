using Authorization.Domain.Configuration;
using Authorization.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Authorization.Domain
{
    public class RepositoryContext : DbContext
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