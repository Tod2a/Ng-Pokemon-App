namespace ng_pokemon.Domain.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
}
