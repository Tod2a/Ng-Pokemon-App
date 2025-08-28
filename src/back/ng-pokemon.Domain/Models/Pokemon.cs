
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
    /// Gets the date and time when the Pokémon entity was created.
    /// </summary>
    public DateTime Created { get; private set; }

    /// <summary>
    /// Navigation property: collection of type links associated with the Pokémon.
    /// </summary>
    public ICollection<PokemonType> PokemonTypes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Pokemon"/> class with default values.
    /// </summary>
    public Pokemon()
    {
        Name = string.Empty;
        Img_path = string.Empty;
        PokemonTypes = [];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Pokemon"/> class with provided values.
    /// </summary>
    /// <param name="id">The unique identifier of the Pokémon.</param>
    /// <param name="name">The name of the Pokémon.</param>
    /// <param name="hp">The hit points (HP) of the Pokémon.</param>
    /// <param name="cp">The combat power (CP) of the Pokémon.</param>
    /// <param name="picture">The image path of the Pokémon.</param>
    public Pokemon(int id, string name, int hp, int cp, string picture, List<PokemonType> types)
    {
        Id = id;
        Name = name;
        Hp = hp;
        Cp = cp;
        Img_path = picture;
        PokemonTypes = types;
        Created = DateTime.UtcNow;
    }
}
