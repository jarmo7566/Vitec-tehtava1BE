using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VitecTehtava1.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default") ?? 
    throw new InvalidOperationException("Connection string 'Default' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapControllers();

app.Run();
