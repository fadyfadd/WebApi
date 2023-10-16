
using Microsoft.EntityFrameworkCore;

namespace WebApi.EntityFrameworkContext;

public class SakilaDataContext : DbContext
{
 
    public DbSet<Actor> Actors {set; get;}

    public DbSet<ActorFilm> ActorFilms {set; get;}

    public DbSet<Film> Films {set; get;}

    public SakilaDataContext(DbContextOptions<SakilaDataContext> sakilaDataContext) : base(sakilaDataContext) {
      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new ActorFilmConfiguration());
        modelBuilder.ApplyConfiguration(new FilmConfiguration());
    }
}
