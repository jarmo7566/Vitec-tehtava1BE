using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VitecTehtava1.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Problems loading reference "https>json.schemastore.org... 
//TODO: Fix later pirullinen vika, joka johtuu palvelun ylikuormituksesta
//string connectionString = builder.Configuration.GetConnectionString("Default") ?? 
//throw new InvalidOperationException("Connection string 'Default' not found.");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=UserDb;Username=postgres;Password=psLDV2"));

var app = builder.Build();

app.MapControllers();

app.Run();
