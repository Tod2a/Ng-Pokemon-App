import { Pipe, PipeTransform } from '@angular/core';
import { PokemonType } from '../../datas/enums/pokemon-types.enum';

@Pipe({
  name: 'pokemonTypeColor',
  standalone: true
})
export class PokemonTypeColorPipe implements PipeTransform {

  private readonly typeColors: Record<PokemonType, string> = {
    [PokemonType.Feu]: 'red lighten-1',
    [PokemonType.Eau]: 'blue lighten-1',
    [PokemonType.Plante]: 'green lighten-1',
    [PokemonType.Insecte]: 'green lighten-3',
    [PokemonType.Normal]: 'grey lighten-3',
    [PokemonType.Vol]: 'blue lighten-3',
    [PokemonType.Poison]: 'deep-purple accent-1',
    [PokemonType.Fée]: 'pink lighten-4',
    [PokemonType.Psy]: 'deep-purple darken-2',
    [PokemonType.Électrik]: 'lime accent-1',
    [PokemonType.Combat]: 'deep-orange',
    [PokemonType.Acier]: 'grey',
    [PokemonType.Dragon]: 'purple darken-1',
    [PokemonType.Glace]: 'cyan lighten-4',
    [PokemonType.Roche]: 'brown darken-2',
    [PokemonType.Sol]: 'amber darken-2',
    [PokemonType.Spectre]: 'indigo darken-3',
    [PokemonType.Ténèbres]: 'blue-grey darken-3'
  };

   transform(type: PokemonType | string): string {
    const normalizedType = type in PokemonType ? type as PokemonType : null;

    const colorClass = normalizedType && this.typeColors[normalizedType]
      ? this.typeColors[normalizedType]
      : 'grey';

    return `chip ${colorClass}`;
  }
}
