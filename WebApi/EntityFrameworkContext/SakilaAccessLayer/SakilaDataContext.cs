
using Microsoft.EntityFrameworkCore;

namespace WebApi.EntityFrameworkContext;

public class SakilaDataContext : DbContext
{
    private String connectionString; 

    public DbSet<Actor> Actors {set; get;}

    public DbSet<ActorFilm> ActorFilms {set; get;}

    public DbSet<Film> Films {set; get;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new ActorFilmConfiguration());
        modelBuilder.ApplyConfiguration(new FilmConfiguration());
    }

    public SakilaDataContext(String connectionString) {
        this.connectionString = connectionString;
    }

}
