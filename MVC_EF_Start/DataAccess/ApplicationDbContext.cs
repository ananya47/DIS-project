using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<State> State_tab { get; set; }
        public DbSet<City> City_tab { get; set; }
        public DbSet<Company> Company_tab { get; set; }
        public DbSet<Boat> Boats_tab { get; set; }
    }

}