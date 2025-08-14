import { Component, OnInit } from '@angular/core';
import { Pokemon } from './datas/models/pokemon';
import { POKEMONS } from './datas/mocks/mock-pokemon-list';
import { SHARED_IMPORTS } from './shared/imports';
import { BorderCardDirective } from './shared/directives/border-card.directive';
import { PokemonTypeColorPipe } from './shared/pipes/pokemon-type-color.pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SHARED_IMPORTS, BorderCardDirective, PokemonTypeColorPipe],
  templateUrl: 'app.component.html'
})
export class AppComponent implements OnInit {
  pokemonList: Pokemon[] = POKEMONS;
  pokemonSelected: Pokemon|undefined;

  ngOnInit(): void {
    console.table(this.pokemonList);
  }

  selectPokemon(pokemonId: string) {
    const pokemon: Pokemon|undefined = this.pokemonList.find(pokemon => pokemon.id == +pokemonId)
    
    if (pokemon){
      console.log(`Vous avez demandé le pokémon ${pokemon.name}`);
      this.pokemonSelected = pokemon;
    } else {
      console.log(`Vous avez demandé un pokémon qui n'existe pas`);
      this.pokemonSelected = pokemon;
    }
  }
}
