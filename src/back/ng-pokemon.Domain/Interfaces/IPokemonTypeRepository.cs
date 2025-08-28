using ng_pokemon.Domain.Models;

namespace ng_pokemon.Domain.Interfaces;

/// <summary>
/// Defines the contract for accessing Pokémon types from the data source.
/// </summary>
public interface IPokemonTypeRepository
{
    /// <summary>
    /// Retrieves a list of Pokémon types by their unique identifiers.
    /// </summary>
    /// <param name="ids">The list of type identifiers to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="PokemonType"/> objects.
    /// </returns>
    Task<List<PokemonType>> GetByIdsAsync(List<int> ids);
}
