using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ng_pokemon.Domain.Interfaces;
using ng_pokemon.Infrastructure.Data;
using ng_pokemon.Infrastructure.Repositories;

namespace ng_pokemon.Infrastructure;

/// <summary>
/// Provides extension methods to register Infrastructure services
/// into the dependency injection container.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Registers the Infrastructure services and database context
    /// with the specified connection string.
    /// </summary>
    /// <param name="services">The service collection to register services into.</param>
    /// <param name="connectionString">The connection string for the SQL Server database.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IPokemonRepository, PokemonRepository>();

        return services;
    }
}
