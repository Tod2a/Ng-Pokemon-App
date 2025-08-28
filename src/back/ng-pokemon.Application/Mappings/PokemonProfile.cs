using AutoMapper;
using ng_pokemon.Application.DTOs;
using ng_pokemon.Domain.Models;

namespace ng_pokemon.Application.Mappings;

public class PokemonProfile : Profile
{
    public PokemonProfile() 
    {
        CreateMap<Pokemon, PokemonListResponseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ImgPath, opt => opt.MapFrom(src => src.Img_path))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.PokemonTypes));

        CreateMap<Pokemon, PokemonDetailResponseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ImgPath, opt => opt.MapFrom(src => src.Img_path))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.Cp, opt => opt.MapFrom(src => src.Cp))
            .ForMember(dest => dest.Hp, opt => opt.MapFrom(src => src.Hp))
            .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.PokemonTypes));

        CreateMap<PokemonCreateDTO, Pokemon>()
            .ConstructUsing(dto => new Pokemon(
                0,
                dto.Name,
                dto.Hp,
                dto.Cp,
                dto.ImgPath,
                new List<PokemonType>()
            ));

        CreateMap<PokemonType, PokemonTypeResponseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
