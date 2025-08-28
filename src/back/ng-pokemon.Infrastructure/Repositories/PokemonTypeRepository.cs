using Microsoft.EntityFrameworkCore;
using ng_pokemon.Domain.Interfaces;
using ng_pokemon.Domain.Models;
using ng_pokemon.Infrastructure.Data;

namespace ng_pokemon.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for accessing Pokémon types.
/// </summary>
public class PokemonTypeRepository(AppDbContext context) : IPokemonTypeRepository
{
    private readonly AppDbContext _context = context;

    /// <summary>
    /// Retrieves a list of Pokémon types by their unique identifiers.
    /// </summary>
    /// <param name="ids">The list of type identifiers to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="PokemonType"/> objects.
    /// </returns>
    public async Task<List<PokemonType>> GetByIdsAsync(List<int> ids)
    {
        return await _context.PokemonTypes
           .Where(t => ids.Contains(t.Id))
           .ToListAsync();
    }
}
