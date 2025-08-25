using ng_pokemon.Domain.Models;

namespace ng_pokemon.Application.Interfaces;

/// <summary>
/// Defines the application service contract for managing Pokémon.
/// Provides methods to retrieve Pokémon data.
/// </summary>
public interface IPokemonService
{
    /// <summary>
    /// Retrieves a paginated list of all Pokémon.
    /// </summary>
    /// <param name="pageNumber">The current page number (starting at 1).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="Pokemon"/>.
    /// </returns>
    Task<List<Pokemon>> GetAllAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Retrieves a Pokémon by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Pokémon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <see cref="Pokemon"/> if found, otherwise <c>null</c>.
    /// </returns>
    Task<Pokemon?> GetByIdAsync(int id);
}
