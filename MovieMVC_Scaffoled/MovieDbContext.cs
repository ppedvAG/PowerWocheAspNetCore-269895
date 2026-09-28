using Microsoft.EntityFrameworkCore;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<MovieMVC_Scaffoled.Models.Movie> Movie { get; set; } = default!;
}
