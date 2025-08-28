
namespace ng_pokemon.Domain.Models;

/// <summary>
/// Represents a Pokémon type (e.g., Fire, Water, Grass).
/// </summary>
public class PokemonType
{
    /// <summary>
    /// Gets or sets the unique identifier for the type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the display name of the Pokémon type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Navigation property: collection of Pokémon that belong to this type.
    /// </summary>
    public ICollection<Pokemon> Pokemons { get; set; } = [];
}
