using RestWithASPNET10.Configurations;
using RestWithASPNET10.Services.Implementations;
using RestWithASPNET10.Repositories.Implementations;
using RestWithASPNET10.Repositories.Interfaces;
using RestWithASPNET10.Services.Interfaces;
using RestWithASPNET10.Services.Implementations.v2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddSerilog();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPersonServices, PersonServices>();

builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<PersonServicesV2>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
