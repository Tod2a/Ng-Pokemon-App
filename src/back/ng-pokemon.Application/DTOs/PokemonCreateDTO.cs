using System.ComponentModel.DataAnnotations;

namespace ng_pokemon.Application.DTOs;

/// <summary>
/// Data Transfer Object used to create a new Pokémon.
/// </summary>
public class PokemonCreateDTO
{
    /// <summary>
    /// Gets or sets the name of the Pokémon.
    /// </summary>
    /// <example>Pikachu</example>
    [Required(ErrorMessage = "The Pokémon name is required.")]
    [StringLength(100, ErrorMessage = "The Pokémon name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the hit points (HP) of the Pokémon.
    /// </summary>
    /// <example>35</example>
    public int Hp { get; set; }

    /// <summary>
    /// Gets or sets the combat power (CP) of the Pokémon.
    /// </summary>
    /// <example>55</example>
    public int Cp { get; set; }

    /// <summary>
    /// Gets or sets the image path (URL or relative path) of the Pokémon.
    /// </summary>
    /// <example>images/pikachu.png</example>
    public string ImgPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of type identifiers associated with the Pokémon.
    /// </summary>
    /// <example>[1, 5]</example>
    public List<int> TypeIds { get; set; } = [];
}
