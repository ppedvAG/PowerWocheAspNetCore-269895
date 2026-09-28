using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EFCore_Relationships.Models;

namespace RazorPages_with_EFCore_Relationships.Data
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext (DbContextOptions<GeoDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPages_with_EFCore_Relationships.Models.Continent> Continent { get; set; } = default!;
        public DbSet<RazorPages_with_EFCore_Relationships.Models.Language> Language { get; set; } = default!;
        public DbSet<RazorPages_with_EFCore_Relationships.Models.Country> Country { get; set; } = default!;
        public DbSet<RazorPages_with_EFCore_Relationships.Models.LanguageInCountry> LanguageInCountry { get; set; } = default!;
    }
}
