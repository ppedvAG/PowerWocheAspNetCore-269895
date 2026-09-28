using Microsoft.EntityFrameworkCore;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<MovieRazorPages.Models.Movie> Movie { get; set; } = default!;
}
