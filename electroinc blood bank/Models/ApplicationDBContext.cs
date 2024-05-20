
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace electroinc_blood_bank.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext() { }



        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;database=BloodBank;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Donor> Donors { get; set; } = null;
        public virtual DbSet<DonorHistory> DonorsHistory { get; set; } = null;
        public virtual DbSet<Hospital> Hospitals { get; set; } = null;
        public virtual DbSet<Reciptionist> Reciptionists { get; set; } = null;
        public virtual DbSet<Blood> Bloods { get; set; } = null;
        public virtual DbSet<Orders> Orders { get; set; } = null;
        public virtual DbSet<BloodQuantity> BloodQuantities { get; set; } = null;
        public virtual DbSet<BloodBank> BloodBanks { get; set; }
        public virtual DbSet<Patient> Patients { get; set; } = null;
        public virtual DbSet<Event> Events { get; set; } = null;
        public virtual DbSet<Manager> Managers { get; set; } = null;



    }
}

