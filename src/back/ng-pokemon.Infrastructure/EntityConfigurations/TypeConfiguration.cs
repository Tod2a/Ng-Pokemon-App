using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonType = ng_pokemon.Domain.Models.PokemonType;

namespace ng_pokemon.Infrastructure.EntityConfigurations;

internal class TypeConfiguration : IEntityTypeConfiguration<PokemonType>
{
    public void Configure(EntityTypeBuilder<PokemonType> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(30);
    }
}
