namespace WebApi.EntityFrameworkContext;

public class Actor
{
    public Int32 ActorId {set; get;}
    public String FirstName {set; get;}
    public String LastName {set; get;}
    public DateTime LastUpdate {set; get;}
    public ICollection<ActorFilm> ActorFilms {set; get;} 

}
