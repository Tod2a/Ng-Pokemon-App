using AutoMapper;
using ng_pokemon.Application.DTOs;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Application.Mappings;

public class PokemonProfile : Profile
{
    public PokemonProfile() 
    {
        CreateMap<Pokemon, PokemonResponseDTO>()
            .ForMember(dest => dest.Types,
                opt => opt.MapFrom(src => src.PokemonTypes.Select(t => t.Name).ToList()));

        CreateMap<PokemonCreateDTO, Pokemon>()
            .ConstructUsing(dto => new Pokemon(
                0,
                dto.Name,
                dto.Hp,
                dto.Cp,
                dto.ImgPath,
                new List<PokemonType>()
            ));
    }
}
