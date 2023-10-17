namespace Infrastructure.WebApi;
using AutoMapper;
using global::WebApi.DataTransferObjects;
using global::WebApi.EntityFrameworkContext;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles() {
      
        CreateMap<Actor , ActorDto>().ForMember(a=>a.FilmDtos , opt=>opt.MapFrom(b=>b.ActorFilms)).ReverseMap();
        
        CreateMap<ActorFilm, FilmDto>()
        .ForMember(a=>a.Title , opt=>opt.MapFrom(b=>b.Film.Title))
        .ForMember(a=>a.Description , opt=>opt.MapFrom(b=>b.Film.Description))
        .ForMember(a=>a.ReleaseYear , opt=>opt.MapFrom(b=>b.Film.ReleaseYear))
        .ForMember(a=>a.LanguageId , opt=>opt.MapFrom(b=>b.Film.LanguageId))
        .ForMember(a=>a.OriginalLanguageId , opt=>opt.MapFrom(b=>b.Film.OriginalLanguageId))
        .ForMember(a=>a.RentalDuration , opt=>opt.MapFrom(b=>b.Film.RentalDuration))
        .ForMember(a=>a.RentalRate , opt=>opt.MapFrom(b=>b.Film.RentalRate))
        .ForMember(a=>a.Length , opt=>opt.MapFrom(b=>b.Film.Length))
        .ForMember(a=>a.ReplacementCost , opt=>opt.MapFrom(b=>b.Film.ReplacementCost))
        .ForMember(a=>a.Rating , opt=>opt.MapFrom(b=>b.Film.Rating))
        .ForMember(a=>a.SpecialFeatures , opt=>opt.MapFrom(b=>b.Film.SpecialFeatures))
        .ForMember(a=>a.LastUpdate , opt=>opt.MapFrom(b=>b.Film.LastUpdate));
    }
}
