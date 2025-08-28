using Microsoft.EntityFrameworkCore;
using ng_pokemon.Domain.Models;
using ng_pokemon.Domain.Enums;

namespace ng_pokemon.Infrastructure.Data;

/// <summary>
/// Represents the Entity Framework Core database context for the application.
/// Contains DbSets for all domain entities.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<PokemonType> PokemonTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        string[] typeNames = Enum.GetNames(typeof(PokemonTypeEnum));
        int id = 1;
        foreach (var typeName in typeNames)
        {
            modelBuilder.Entity<PokemonType>().HasData(new PokemonType
            {
                Id = id++,
                Name = typeName
            });
        }
    }
}
