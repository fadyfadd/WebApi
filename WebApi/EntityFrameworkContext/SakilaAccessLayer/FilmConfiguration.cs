using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;

namespace WebApi.EntityFrameworkContext;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("film");
        builder.HasKey(f=>f.FilmId);
        builder.Property(f=>f.FilmId).HasColumnName("film_id");
        builder.Property(f=>f.Title).HasColumnName("title");
        builder.Property(f=>f.Description).HasColumnName("description");
        builder.Property(f=>f.ReleaseYear).HasColumnName("release_year");
        builder.Property(f=>f.LanguageId).HasColumnName("language_id");
        builder.Property(f=>f.OriginalLanguageId).HasColumnName("original_language_id");
        builder.Property(f=>f.RentalDuration).HasColumnName("rental_duration");
        builder.Property(f=>f.RentalRate).HasColumnName("rental_rate");
        builder.Property(f=>f.Length).HasColumnName("length");
        builder.Property(f=>f.ReplacementCost).HasColumnName("replacement_cost");
        builder.Property(f=>f.Rating).HasColumnName("rating");
        builder.Property(f=>f.SpecialFeatures).HasColumnName("special_features");
        builder.Property(f=>f.LastUpdate).HasColumnName("last_update");

        
        builder.HasMany(f=>f.ActorFilms).WithOne(fm=>fm.Film).HasPrincipalKey(f=>f.FilmId).HasForeignKey(fm=>fm.FilmId);
    }
}
