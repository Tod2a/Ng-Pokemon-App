using ng_pokemon.Domain.enums;

namespace ng_pokemon.Domain.Models;

public class Pokemon(int id, string name, int hp, int cp, string img_path, List<PokemonType> types)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int Hp { get; private set; } = hp;
    public int Cp { get; private set; } = cp;
    public string Img_path { get; private set; } = img_path;
    public List<PokemonType> PokemonTypes { get; private set; } = types;
    public DateTime Created { get; private set; } = DateTime.Now;
}
