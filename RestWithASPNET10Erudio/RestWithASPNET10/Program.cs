using RestWithASPNET10.Configurations;
using RestWithASPNET10.Services.Implementations;
using RestWithASPNET10.Repositories.Implementations;
using RestWithASPNET10.Repositories.Interfaces;
using RestWithASPNET10.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddSerilog();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
