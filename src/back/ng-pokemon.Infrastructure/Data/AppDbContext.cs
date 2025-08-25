using Microsoft.EntityFrameworkCore;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Infrastructure.Data;

/// <summary>
/// Represents the Entity Framework Core database context for the application.
/// Contains DbSets for all domain entities.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pokemon> Pokemon { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
