using Microsoft.EntityFrameworkCore;
using WebApi.EntityFrameworkContext;

namespace WebApi.Services;

public class ActorService
{
    SakilaDataContext sakilaDataContext;
    public ActorService(SakilaDataContext sakilaDataContext) {
        this.sakilaDataContext = sakilaDataContext; 
    }

    public List<Actor> GetActors() {
        return sakilaDataContext.Actors.ToList();
    }
}
