

namespace WebApi.DataTransferObjects;

public class ActorDto
{
    public Int32 ActorId {set; get;}
    public String FirstName {set; get;}
    public String LastName {set; get;}
    public DateTime LastUpdate {set; get;}
    public ICollection<FilmDto> FilmDtos {set; get;} 

}
