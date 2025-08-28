using ng_pokemon.Application.Interfaces;
using ng_pokemon.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using ng_pokemon.Application.Mappings;

namespace ng_pokemon.Application;

/// <summary>
/// Provides extension methods to register Application services
/// into the dependency injection container.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Registers the Application services for the Pokémon domain
    /// into the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to register services into.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();

        services.AddAutoMapper(cfg => { }, typeof(PokemonProfile).Assembly);

        return services;
    }
}
