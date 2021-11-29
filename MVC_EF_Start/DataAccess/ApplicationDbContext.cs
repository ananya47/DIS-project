using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // public DbSet<Company> Companies { get; set; }
        // public DbSet<Quote> Quotes { get; set; }

        public DbSet<Boat> Boats_tab { get; set; }
        public DbSet<State> State_tab { get; set; }
        public DbSet<Company> Company_tab { get; set; }
        public DbSet<City> City_tab { get; set; }

        //public DbSet<Georeference> Georeference { get; set; }

        //public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        //public DbSet<Brand> Brands { get; set; }
        //public DbSet<Medicine> Medicines { get; set; }
        //public DbSet<Prescription> Prescriptions { get; set; }
        //public DbSet<Appointment> Appointments { get; set; }


    }

}