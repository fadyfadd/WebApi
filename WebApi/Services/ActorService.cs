using Microsoft.EntityFrameworkCore;
using WebApi.EntityFrameworkContext;

namespace WebApi.Services;

public class ActorService
{
    SakilaDataContext sakilaDataContext;
    public ActorService(SakilaDataContext sakilaDataContext) {
        this.sakilaDataContext = sakilaDataContext; 
    }

    public List<Actor> GetSakilaMoviesByActor(Int32 actorId) {
        return sakilaDataContext.Actors.Include(f=>f.ActorFilms).ThenInclude(f=>f.Film).Where(a=>a.ActorId == actorId).ToList();
    }
}
