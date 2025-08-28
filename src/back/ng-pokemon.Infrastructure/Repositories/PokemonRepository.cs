using ng_pokemon.Domain.Models;
using ng_pokemon.Domain.Interfaces;
using ng_pokemon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ng_pokemon.Infrastructure.Repositories;

/// <summary>
/// Implements the <see cref="IPokemonRepository"/> interface using Entity Framework Core.
/// Provides methods to access Pokémon data from the database.
/// </summary>
public class PokemonRepository(AppDbContext context) : IPokemonRepository
{
    private readonly AppDbContext _context = context;

    /// <summary>
    /// Retrieves a paginated list of all Pokémon from the database.
    /// </summary>
    /// <param name="pageNumber">The current page number (starting at 1).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="Pokemon"/>.
    /// </returns>
    public async Task<(List<Pokemon>, int)> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Pokemon
            .Include (p => p.PokemonTypes)
            .AsQueryable();

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    /// <summary>
    /// Retrieves a Pokémon by its unique identifier from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the Pokémon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <see cref="Pokemon"/> if found, otherwise <c>null</c>.
    /// </returns>
    public async Task<Pokemon?> GetByIdAsync(int id)
    {
        return await _context.Pokemon
            .Include(p => p.PokemonTypes)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Adds a new Pokémon to the database.
    /// </summary>
    /// <param name="pokemon">The <see cref="Pokemon"/> entity to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddAsync(Pokemon pokemon)
    {
        await _context.Pokemon.AddAsync(pokemon);

        await _context.SaveChangesAsync();
    }
}
