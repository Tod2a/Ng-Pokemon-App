namespace ng_pokemon.Application.DTOs;

/// <summary>
/// Data Transfer Object used to represent light Pokémon informations in API responses.
/// </summary>
public class PokemonListResponseDTO
{
    /// <summary>
    /// Gets or sets the unique identifier of the Pokémon.
    /// </summary>
    /// <example>25</example>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Pokémon.
    /// </summary>
    /// <example>Pikachu</example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the image path (URL or relative path) of the Pokémon.
    /// </summary>
    /// <example>images/pikachu.png</example>
    public string ImgPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the Pokémon was created in the system.
    /// </summary>
    /// <example>2025-08-28T14:30:00Z</example>
    public DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the list of type names associated with the Pokémon.
    /// </summary>
    /// <example>["Electric"]</example>
    public List<PokemonTypeResponseDTO> Types { get; set; } = [];
}
