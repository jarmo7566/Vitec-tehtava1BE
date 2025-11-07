using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VitecTehtava1.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173",
                                              "http://www.contoso.com").AllowAnyHeader()
                                                  .AllowAnyMethod();;
                      });
});

builder.Services.AddControllers();

//Problems loading reference "https>json.schemastore.org... 
//TODO: Fix later pirullinen vika, joka johtuu palvelun ylikuormituksesta
//string connectionString = builder.Configuration.GetConnectionString("Default") ?? 
//throw new InvalidOperationException("Connection string 'Default' not found.");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=UserDb;Username=postgres;Password=psLDV2"));

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
