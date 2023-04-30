using Microsoft.EntityFrameworkCore;
using NSolve.Domain.Entities;

namespace NSolve.Infrastructure.DAL;

public class SolveDbContext : DbContext
{
    public SolveDbContext(DbContextOptions<SolveDbContext> options)
        : base(options)
    {
    }

    public DbSet<Draw> Draws { get; set; }

    public DbSet<Secrets> Secrets { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Notification>  Notifications {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}