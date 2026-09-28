using EFCoreFluentAPISample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreFluentAPISample.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(m => m.Rating);

            builder.Property(m => m.Year)
                .IsRequired();

            builder.Property(m => m.WinOscar);

            builder.Property(m => m.Genre)
                .IsRequired();
        }
    }
}
