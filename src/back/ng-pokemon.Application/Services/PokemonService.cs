using ng_pokemon.Application.Interfaces;
using ng_pokemon.Domain.Interfaces;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Application.Services;

/// <summary>
/// Implements the <see cref="IPokemonService"/> interface.
/// Provides methods to manage Pokémon entities using the repository.
/// </summary>
public class PokemonService(IPokemonRepository pokemonRepository) : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository = pokemonRepository;

    /// <summary>
    /// Retrieves a paginated list of all Pokémon.
    /// Ensures that pageNumber and pageSize have valid values.
    /// </summary>
    /// <param name="pageNumber">The current page number (starting at 1).</param>
    /// <param name="pageSize">The number of items per page (minimum 1).</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="Pokemon"/>.
    /// </returns>
    public async Task<List<Pokemon>> GetAllAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;
        return await _pokemonRepository.GetAllAsync(pageNumber, pageSize);
    }

    /// <summary>
    /// Retrieves a Pokémon by its unique identifier.
    /// Returns null if the id is less than 1 or the Pokémon does not exist.
    /// </summary>
    /// <param name="id">The unique identifier of the Pokémon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <see cref="Pokemon"/> if found, otherwise <c>null</c>.
    /// </returns>
    public async Task<Pokemon?> GetByIdAsync(int id)
    {
        if (id < 1) return null;
        return await _pokemonRepository.GetByIdAsync(id);
    }
}
