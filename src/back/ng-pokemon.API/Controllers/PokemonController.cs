using Microsoft.AspNetCore.Mvc;
using ng_pokemon.Application.Interfaces;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.API.Controllers;

/// <summary>
/// Controller responsible for handling Pokémon API requests.
/// Provides endpoints to retrieve Pokémon data.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PokemonController(IPokemonService pokemonService) : Controller
{
    private readonly IPokemonService _pokemonService = pokemonService;

    /// <summary>
    /// Retrieves a paginated list of all Pokémon.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve (default is 1).</param>
    /// <param name="pageSize">The number of items per page (default is 10).</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="Pokemon"/>.
    /// Returns HTTP 200 OK with the list.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<List<Pokemon>>> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        var pokemons = await _pokemonService.GetAllAsync(pageNumber, pageSize);
        return Ok(pokemons);
    }

    /// <summary>
    /// Retrieves a Pokémon by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Pokémon.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing the <see cref="Pokemon"/> if found.
    /// Returns HTTP 404 Not Found if the Pokémon does not exist.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> GetById(int id)
    {
        var pokemon = await _pokemonService.GetByIdAsync(id);

        if (pokemon == null)
        {
            return NotFound();
        }

        return Ok(pokemon);
    }
}
