using ChatApi.Data;
using ChatApi.GraphQL;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --> DbContext
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ChatApi"));
builder.Services.AddDbContextFactory<AppDbContext>(opt => opt.UseInMemoryDatabase("ChatApi"));

// --> GraphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutations>()
    .AddType<UserType>()
    .AddType<ChatType>()
    .AddFiltering()
    .AddSorting();
    //.AddProjections();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod());

PreDb.PrePoupulation(app, app.Environment.IsProduction());

// --> GraphQL
app.MapGraphQL();

app.Run("http://localhost:5000");