using JwtApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Infra.Context;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Matches> Matches { get; set; }
    public DbSet<Teams> Teams { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teams>()
            .HasMany(t => t.Matches)
            .WithOne(m => m.Teams)
            .HasForeignKey(m => m.HomeTeamId)
            .IsRequired();

        modelBuilder.Entity<Teams>()
            .HasMany(t => t.Matches)
            .WithOne(m => m.Teams)
            .HasForeignKey(m => m.AwayTeamId)
            .IsRequired();
    }
}