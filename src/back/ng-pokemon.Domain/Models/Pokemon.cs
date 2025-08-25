using ng_pokemon.Domain.enums;

namespace ng_pokemon.Domain.Models;

/// <summary>
/// Represents a Pokémon entity in the domain.
/// A Pokémon has an identifier, a name, stats (HP and CP),
/// an image path, and one or two types.
/// </summary>
public class Pokemon
{
    /// <summary>
    /// Gets the unique identifier of the Pokémon.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the Pokémon.
    /// </summary>
    public string Name { get; private set; } 

    /// <summary>
    /// Gets the hit points (HP) of the Pokémon.
    /// </summary>
    public int Hp { get; private set; } 

    /// <summary>
    /// Gets the combat power (CP) of the Pokémon.
    /// </summary>
    public int Cp { get; private set; } 

    /// <summary>
    /// Gets the image path of the Pokémon.
    /// </summary>
    public string Img_path { get; private set; } 

    /// <summary>
    /// Gets the list of types associated with the Pokémon.
    /// A Pokémon can have one or two types.
    /// </summary>
    public List<PokemonType> Types { get; private set; }

    /// <summary>
    /// Gets the date and time when the Pokémon entity was created.
    /// </summary>
    public DateTime Created { get; private set; }

    public Pokemon()
    {
        Name = string.Empty;
        Img_path = string.Empty;
        Types = [];
    }

    public Pokemon(int id, string name, int hp, int cp, string picture, List<PokemonType> types)
    {
        Id = id;
        Name = name;
        Hp = hp;
        Cp = cp;
        Img_path = picture;
        Types = types ?? [];
        Created = DateTime.UtcNow;
    }
}
