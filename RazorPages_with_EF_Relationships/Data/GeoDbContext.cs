using Microsoft.EntityFrameworkCore;

public class GeoDbContext(DbContextOptions<GeoDbContext> options) : DbContext(options)
{
    public DbSet<RazorPages_with_EF_Relationships.Models.Continent> Continents { get; set; } = default!;

    public DbSet<RazorPages_with_EF_Relationships.Models.Language> Languages { get; set; } = default!;

    public DbSet<RazorPages_with_EF_Relationships.Models.Country> Countries { get; set; } = default!;

    public DbSet<RazorPages_with_EF_Relationships.Models.LanguageInCountry> LanguageInCountries { get; set; } = default!;
}
