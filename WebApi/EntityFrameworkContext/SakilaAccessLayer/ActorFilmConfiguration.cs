using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.EntityFrameworkContext;

public class ActorFilmConfiguration : IEntityTypeConfiguration<ActorFilm>
{
    public void Configure(EntityTypeBuilder<ActorFilm> builder)
    {
        builder.ToTable("film_actor");
        builder.HasKey(af=>new { af.ActorId , af.FilmId});
        builder.Property(af=>af.FilmId).HasColumnName("film_id");
        builder.Property(af=>af.ActorId).HasColumnName("actor_id");
        builder.Property(af=>af.LastUpdate).HasColumnName("last_update");

        //builder.HasOne(fm=>fm.Actor).WithMany(a=>a.ActorFilms).HasForeignKey(fm=>fm.ActorId);
        //builder.HasOne(fm=>fm.Film).WithMany(f=>f.ActorFilms).HasForeignKey(fm=>fm.FilmId);
    }
}















