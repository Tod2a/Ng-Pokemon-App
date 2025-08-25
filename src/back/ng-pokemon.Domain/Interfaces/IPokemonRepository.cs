using System.Collections.Generic;
using System.Threading.Tasks;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Domain.Interfaces;

public interface IPokemonRepository
{
    /// <summary>
    /// Get a paginated pokemon list
    /// </summary>
    /// <param name="pageNumber">Page number (1-based).</param>
    /// <param name="pageSize">Number of elements by page.</param>
    /// <returns>Paginated list of pokemon.</returns>
    Task<List<Pokemon>> GetAllAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Retrieve a pokemon by id.
    /// </summary>
    /// <param name="id">Pokemon id.</param>
    /// <returns>Pokemon or null.</returns>
    Task<Pokemon?> GetByIdAsync(int id);
}
