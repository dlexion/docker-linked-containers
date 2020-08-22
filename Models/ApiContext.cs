using Microsoft.EntityFrameworkCore;

namespace Cities.Models
{
    public class CitiesContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public CitiesContext(DbContextOptions<CitiesContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City() { Id = 1, Contry = "US", Name = "New York", Population = 8000000 });
        }
    }
}