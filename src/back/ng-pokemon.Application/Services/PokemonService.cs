using AutoMapper;
using Microsoft.Extensions.Logging;
using ng_pokemon.Application.DTOs;
using ng_pokemon.Application.Interfaces;
using ng_pokemon.Domain.Exceptions;
using ng_pokemon.Domain.Interfaces;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Application.Services;

/// <summary>
/// Implements the <see cref="IPokemonService"/> interface.
/// Provides methods to manage Pokémon entities using the repository.
/// </summary>
public class PokemonService(IPokemonRepository pokemonRepository, IPokemonTypeRepository pokemonTypeRepository, IMapper mapper, ILogger<PokemonService> logger) : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository = pokemonRepository;
    private readonly IPokemonTypeRepository _pokemonTypeRepository = pokemonTypeRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<PokemonService> _logger = logger;

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
    public async Task<PagedResponse<PokemonListResponseDTO>> GetAllAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        var (pokemon, totalCount) = await _pokemonRepository.GetAllAsync(pageNumber, pageSize);

        var dtoItems = _mapper.Map<List<PokemonListResponseDTO>>(pokemon);

        return new PagedResponse<PokemonListResponseDTO>
        {
            Items = dtoItems,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
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
    public async Task<PokemonDetailResponseDTO> GetByIdAsync(int id)
    {
        if (id < 1) throw new Exception();

        var pokemon = await _pokemonRepository.GetByIdAsync(id) ?? throw new NotFoundException("No Pokemon Found.");

        var response = _mapper.Map<PokemonDetailResponseDTO>(pokemon);

        return response;
    }

    /// <summary>
    /// Adds a new Pokémon to the system.
    /// Maps the <see cref="PokemonCreateDTO"/> to a <see cref="Pokemon"/> entity
    /// and saves it through the repository.
    /// </summary>
    /// <param name="pokemon">The DTO containing the Pokémon creation data.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddAsync(PokemonCreateDTO pokemon)
    {
        if (pokemon == null) return;

        _logger.LogInformation($"Start creating a new pokemon {pokemon.Name}");

        try
        {
            var newPokemon = _mapper.Map<Pokemon>(pokemon);

            var types = await _pokemonTypeRepository.GetByIdsAsync(pokemon.TypeIds);

            foreach (var type in types)
            {
                newPokemon.PokemonTypes.Add(type);
            }

            await _pokemonRepository.AddAsync(newPokemon);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating Pokemon");
            throw;
        }
    }
}
