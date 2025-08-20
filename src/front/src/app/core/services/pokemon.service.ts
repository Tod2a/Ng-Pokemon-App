import { Injectable } from '@angular/core';
import { Pokemon } from '../../datas/models/pokemon';
import { POKEMONS } from '../../datas/mocks/mock-pokemon-list';
import { PokemonType } from '../../datas/enums/pokemon-types.enum';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  getPokemonList(): Pokemon[] {
    return POKEMONS;
  }

  getPokemonById(id: number): Pokemon | undefined {
    return POKEMONS.find(pokemon => pokemon.id === id);
  }

  getPokemonTypeList(): PokemonType[] {
    return Object.values(PokemonType);
  }
}
