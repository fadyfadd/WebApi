using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.EntityFrameworkContext;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("actor");
        builder.HasKey(a=>a.ActorId);
        builder.Property(a=>a.ActorId).HasColumnName("actor_id");
        builder.Property(a=>a.FirstName).HasColumnName("first_name");
        builder.Property(a=>a.LastName).HasColumnName("last_name");
        builder.Property(a=>a.LastUpdate).HasColumnName("last_update");

        
        builder.HasMany(a=>a.ActorFilms).WithOne(fm=>fm.Actor).HasPrincipalKey(a=>a.ActorId).
           HasForeignKey(fm=>fm.ActorId);
    }
}
