namespace ng_pokemon.Application.DTOs;

public class PokemonTypeResponseDTO
{
    /// <summary>
    /// Gets or sets the unique identifier of the Type.
    /// </summary>
    /// <example>25</example>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Type.
    /// </summary>
    /// <example>Steel</example>
    public string Name { get; set; } = string.Empty;
}
