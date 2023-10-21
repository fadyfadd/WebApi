using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using WebApi.EntityFrameworkContext;
using WebApi.Services;
using AutoMapper;
using Infrastructure.WebApi;
using WebApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.WebApi;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddDbContext<SakilaDataContext>((options) => options.UseMySQL(appSettings.SakilaConnectionString));
builder.Services.AddScoped<IJwtTokenServices>((sp) => new JwtTokenServices(appSettings));
builder.Services.AddScoped<AccountService>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ActorService>();
builder.Services.AddOptions();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtToken)),
             ValidateIssuer = false,
             ValidateAudience = false,
         };
     });

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("sakila-movies-by-actor", policy =>
        policy
            .RequireAuthenticatedUser());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/authenticate-user", (HttpContext context, IOptions<AppSettings> settings , [FromBody] LoginDto user , AccountService accountService) => { 
    return accountService.AuthenticatedUser(user);
}).WithName("AuthenticateUser");

app.MapGet("/sakila-movies-by-actor/{actorId}", (HttpContext context, IOptions<AppSettings> settings, ActorService actorService, IMapper mapper, [FromRoute()] Int32 actorId) =>
{
    var actors = actorService.GetSakilaMoviesByActor(actorId);
    var result = mapper.Map<List<ActorDto>>(actors);
    return result;
})
.WithName("GetSakilaMoviesByActor").RequireAuthorization("sakila-movies-by-actor")
.WithOpenApi();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.Run();
