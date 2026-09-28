using Microsoft.EntityFrameworkCore;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<RazorPages_mit_EFCore_Scaffolder.Models.Movie> Movie { get; set; } = default!;
}
