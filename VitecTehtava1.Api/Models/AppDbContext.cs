using Microsoft.EntityFrameworkCore;

namespace VitecTehtava1.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {    }
    public DbSet<User> Users { get; set; }

    public DbSet<Wastebin> Wastebins { get; set; }

    public DbSet<Feedback> Feedbacks { get; set; }

} 
