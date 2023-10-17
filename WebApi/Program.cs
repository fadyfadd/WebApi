using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi;
using WebApi.EntityFrameworkContext;
using WebApi.Services;
using AutoMapper;
using Infrastructure.WebApi;
using WebApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>(); 
builder.Services.AddDbContext<SakilaDataContext>((options)=>options.UseMySQL(appSettings.SakilaConnectionString));
builder.Services.AddOptions();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ActorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/sakila-movies-by-actor/{actorId}", (HttpContext context , IOptions<AppSettings> settings , ActorService actorService , IMapper mapper , [FromQuery()] Int32  actorId) =>
{

    var actors =  actorService.GetSakilaMoviesByActor(actorId);
    var result =  mapper.Map<List<ActorDto>>(actors);
    return result; 
})
.WithName("GetSakilaMoviesByActor")
.WithOpenApi();

app.Run();
