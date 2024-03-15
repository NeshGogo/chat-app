using ChatApi.Data;
using ChatApi.GraphQL;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Users;
using HotChocolate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var service = builder.Services;

// Add services to the container.

// --> DbContext
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ChatApi"));
service.AddDbContextFactory<AppDbContext>(opt => opt.UseInMemoryDatabase("ChatApi"));

// --> AutoMapper
service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// --> GraphQL
service.AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutations>()
    .AddType<UserType>()
    .AddType<ChatType>()
    .AddFiltering()
    .AddSorting();
//.AddProjections();

// --> Google Authentication
service.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie("Cookie")
    .AddGoogle(googleOptions =>
    {
        googleOptions.SignInScheme = "Cookie";
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"]; ;
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.AddCors();
service.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

PreDb.PrePoupulation(app, app.Environment.IsProduction());

// --> GraphQL
app.MapGraphQL();

app.MapControllers();

app.Run("http://localhost:5000");