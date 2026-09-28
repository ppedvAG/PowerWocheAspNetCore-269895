using EFCoreFluentAPISample.Data.Configurations;
using EFCoreFluentAPISample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentAPISample.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mithilfe von IEntityTypeConfiguration können wir die Spezifizierung
            //der jeweiligen Tabelle in eine eigene Klasse auslagern
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
