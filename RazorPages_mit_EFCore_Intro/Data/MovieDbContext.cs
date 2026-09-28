using Microsoft.EntityFrameworkCore;
using RazorPages_mit_EFCore_Intro.Models;

namespace RazorPages_mit_EFCore_Intro.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; } = default!;
    }
}
